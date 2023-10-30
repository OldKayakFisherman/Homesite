from flask import Flask, render_template
from datetime import datetime

app = Flask(__name__)

@app.context_processor
def inject_copyright_year():
    return {'copyright_year': datetime.now().strftime('%Y')}

@app.route("/")
def hello_world():
    return render_template('index.html')
