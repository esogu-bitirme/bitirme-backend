import cv2
import numpy as np
from loadModel import *
from pred_model import *

IMG_SIZE = 227
def predictClass(imageName):
    test_image = cv2.imread(f'../BitirmeBackend/API/images/{imageName}')
    test_image = cv2.resize(test_image, (IMG_SIZE, IMG_SIZE))
    test_image = np.expand_dims(test_image, axis=0)
    pred = model.predict(test_image)
    return pred