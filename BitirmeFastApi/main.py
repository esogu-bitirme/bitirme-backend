from fastapi import FastAPI
from predict import *
from fastapi.responses import JSONResponse

app = FastAPI()

@app.get('/{imageName}')
def helloworld(imageName:str):
    pred = predictClass(imageName)
    x = {
        "benign": str(pred[0,0]),
        "malignant": str(pred[0,1]),
        "normal": str(pred[0,2])
    }

    return JSONResponse(content=x)

