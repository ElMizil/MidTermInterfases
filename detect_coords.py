#!/usr/bin/env python3
#Este codigo funciona para detectar un objeto verde y mandar sus coordenadas x,y por un topic de ROS

#Librerias que utilizamos
import cv2
import numpy as np
import rospy
from geometry_msgs.msg import PointStamped
import ctypes

#Iniciamos el nodo de ROS, el publisher de las coordenadas y el mensaje que vamos a mandar
rospy.init_node('Green_detector')
coord_pub = rospy.Publisher('/coords',PointStamped, queue_size=10)
point = PointStamped()


#Iniciamos el video y cargamos la libreria hecha en c++
vid = cv2.VideoCapture(0)
path = "/home/mizil/octavo_semestre/mylibrary.so"
lib = ctypes.cdll.LoadLibrary(path)
func = lib._Z8multi100ii
func.restype = ctypes.POINTER(ctypes.c_int)
  
while(True):
    #Capturamos el video
    ret, frame = vid.read()

    #Convierte la imagen BGR a HSV 
    hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

    #Definimos los valores de la mascara del color verde
    low = np.array([35,80,0])
    up = np.array([92,255,255])

    #Creamos la mascara
    maskG = cv2.inRange(hsv, low, up)

    #Aplicamos bitwise en la imagen usando la mascara
    res = cv2.bitwise_and(frame, frame, mask=maskG)

    #Invertimos blancos y negros
    invert = cv2.bitwise_not(maskG)
    ret, thG = cv2.threshold(invert, 120, 255, cv2.THRESH_TOZERO)

    #Eliminamos ruido
    c, h = cv2.findContours(maskG, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)[-2:]
    threshold_blob_area = 30

    #Dibujamos el contorno del area
    for i in range(1, len(c)):
      index_level = int(h[0][i][1])
      if index_level <= i:
        cnt = c[i]
        area = cv2.contourArea(cnt)
        #print(area)
      if(area) <= threshold_blob_area:
        cv2.drawContours(maskG, [cnt], -1, 0, -1, 1)


    #Encontramos contorno del ruido
    kernel = cv2.getStructuringElement(cv2.MORPH_ELLIPSE, (3,3))
    contour = cv2.morphologyEx(maskG, cv2.MORPH_OPEN, kernel, iterations=4)
    
    #Obtenemos las coordenadas 
    x,y,w,h = cv2.boundingRect(contour)

    #Usamos el metodo de la libreria e imprimos el resultado
    result = func(x,y)
    print(result[0],result[1])
    
    #Armamos el mensaje para publicarlo
    point.header.stamp = rospy.Time.now()
    point.point.x = result[0]
    point.point.y = result[1]

    #Publicamos el mensaje
    coord_pub.publish(point)
    
    #Dibujamos el rectangulo Draw rectangle 
    cv2.rectangle(frame, (x, y), (x + w, y + h), (139,0,0), 4)
    #Desplegamos texto con las coordenadas x,y
    cv2.putText(frame, "x: "+str(x), (x, y+h+25), cv2.FONT_HERSHEY_SIMPLEX, 1, (255,0,255), 2, cv2.LINE_AA)
    cv2.putText(frame, "y: "+str(y), (x+130, y+h+25), cv2.FONT_HERSHEY_SIMPLEX, 1, (255,0,255), 2, cv2.LINE_AA)

    #Desplegamos las imagenes
    cv2.imshow('Frame', frame)
    cv2.imshow("Contour", contour)

    # 'q' = salir
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
  
#Salimos y liberamos el video
vid.release()
#Cerramos las imagenes
cv2.destroyAllWindows()