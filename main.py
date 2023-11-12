import json
from flask import Flask, render_template, request, redirect, url_for, session
from datetime import datetime
from tinydb import TinyDB, Query
from configparser import ConfigParser

config = ConfigParser()
config.read('.env')

app = Flask(__name__)
app.secret_key = config['GENERAL']['SECRET.KEY']


@app.context_processor
def inject_copyright_year():
    return {'copyright_year': datetime.now().strftime('%Y')}

@app.context_processor
def inject_show_contact():

    result = {'show_contact': False}

    if 'show_contact' in session:
        result = {'show_contact': session['show_contact']}

    session['show_contact'] = False

    return result

@app.route("/")
def index():
    return render_template('index.html')

@app.post("/contact")
def contact():

    # Check for the nonce, if there is then this was most likely submitted by an auto process

    if 'chkNonce' not in request.form:
        if request.form['txtContactEmail'] and request.form['txtReason']:
            write_contact_request(str(request.form['txtContactEmail']),
                                  str(request.form['txtReason']))

            session['show_contact'] = True

    return redirect(url_for('index'))


@app.get("/contact_submissions")
def contact_submissions():
    db = TinyDB('db.json')
    token = request.args.get('token', '')
    stored_token = config['GENERAL']['SECRET.KEY']

    if token == stored_token:
        return json.dumps(db.all())


def write_contact_request(email:str, reason:str):

    db = TinyDB('db.json')

    # Check to see if there is a previous contact
    Contact = Query()

    result = db.search(Contact.email == email)

    print(result)

    if not result:
        # User hasn't contacted us previously
        db.insert({'email': email, 'reason': reason})



