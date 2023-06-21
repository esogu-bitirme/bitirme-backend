from fastapi import FastAPI
from predict import *
from fastapi.responses import JSONResponse
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()

# CORS yapılandırmasını yapma
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


@app.get('/{imageName}')
def helloworld(imageName:str):
    pred = predictClass(imageName)
    x = {
        "benign": str(pred[0,0]),
        "malignant": str(pred[0,1]),
        "normal": str(pred[0,2])
    }

    return JSONResponse(content=x)

