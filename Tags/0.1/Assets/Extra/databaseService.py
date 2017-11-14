#!/usr/bin/env python
# -*- coding: utf-8 -*-
import json
import sqlite3
from bottle import route, run, template, request

connection = None
cursor = None

@route('/hello/<name>')
def index(name):
    return template('<b>Hello {{name}}</b>!', name=name)

@route('/test/electricity', method='POST')
def index():
    postdata = request.body.read()
    print (postdata) #this goes to log file only, not to client
    timestamp = request.forms.get("timestamp")
    phaseId = request.forms.get("phaseId")
    activePower = request.forms.get("activePower")
    reactivePower = request.forms.get("reactivePower")
    cursor.execute("insert into Electricity (timestamp, phaseId, activePower, reactivePower) values (?,?,?,?)", (timestamp, phaseId, activePower, reactivePower))
    connection.commit()
    return "200"

@route('/test/rfid', method='POST')
def index():
    postdata = request.body.read()
    print (postdata) #this goes to log file only, not to client
    # timestamp = request.forms.get("timestamp")
    # phaseId = request.forms.get("phaseId")
    # return "Hi {timestamp} {phaseId}".format(timestamp=timestamp, phaseId=phaseId)
    timestamp = request.forms.get("timestamp")
    antenaId = request.forms.get("antenaId")
    signalStrenght = request.forms.get("signalStrenght")
    tagId = request.forms.get("tagId")
    cursor.execute("insert into RFID (timestamp, antenaId, signalStrenght, tagId) values (?,?,?,?)", (timestamp, antenaId, signalStrenght, tagId))
    connection.commit()
    return "200"

@route('/data/electricity', method='POST')
def index():
    electricityDataCounter = request.forms.get("electricityDataCounter")
    for i in range(0, int(electricityDataCounter)):
        timestamp = request.forms.get("timestamp"+str(i))
        phaseId = request.forms.get("phaseId"+str(i))
        activePower = request.forms.get("activePower"+str(i))
        reactivePower = request.forms.get("reactivePower"+str(i))
        cursor.execute("insert into Electricity (timestamp, phaseId, activePower, reactivePower) values (?,?,?,?)", (timestamp, phaseId, activePower, reactivePower))
        connection.commit()
    print(request.forms.get("phaseId"+str(0)))
    return "200"

@route('/data/rfid', method='POST')
def index():
    rfidDataCounter = request.forms.get("rfidDataCounter")
    for i in range(0, int(rfidDataCounter)):
        timestamp = request.forms.get("timestamp"+str(i))
        antenaId = request.forms.get("antenaId"+str(i))
        signalStrenght = request.forms.get("signalStrenght"+str(i))
        tagId = request.forms.get("tagId"+str(i))
        cursor.execute("insert into RFID (timestamp, antenaId, signalStrenght, tagId) values (?,?,?,?)", (timestamp, antenaId, signalStrenght, tagId))
        connection.commit()
    return "200"

@route('/data/binarySensor', method='POST')
def index():
    binarySensorDataCounter = request.forms.get("binarySensorDataCounter")
    for i in range(0, int(binarySensorDataCounter)):
        timestamp = request.forms.get("timestamp"+str(i))
        id = request.forms.get("id"+str(i))
        type = request.forms.get("type"+str(i))
        value = request.forms.get("value"+str(i))
        cursor.execute("insert into BinarySensor (timestamp, sensorId, type, value) values (?,?,?,?)", (timestamp, id, type, value))
        connection.commit()
    print(request.forms.get("id"+str(0)))
    return "200"

@route('/data/ultrasound', method='POST')
def index():
    ultrasoundDataCounter = request.forms.get("ultrasoundDataCounter")
    for i in range(0, int(ultrasoundDataCounter)):
        timestamp = request.forms.get("timestamp"+str(i))
        id = request.forms.get("id"+str(i))
        value = request.forms.get("value"+str(i))
        cursor.execute("insert into Ultrasound (timestamp, sensorId, value) values (?,?,?)", (timestamp, id, value))
        connection.commit()
    print(request.forms.get("id"+str(0)))
    return "200"

@route('/data/actuator', method='GET')
def index():
    print(request.forms.get("id"))
    return "200"

connection = sqlite3.connect("smarthome.db")
cursor = connection.cursor()
cursor.execute("create table if not exists Electricity (timestamp character(255), phaseId character(2), activePower integer, reactivePower integer)")
connection.commit()
cursor.execute("create table if not exists RFID (timestamp character(255), antenaId character(255), signalStrenght integer, tagId character(255))")
connection.commit()
cursor.execute("create table if not exists TagRFIDName (timestamp character(255), tagId character(255), tagName character(255))")
connection.commit()
cursor.execute("create table if not exists BinarySensor (timestamp character(255), sensorId character(255), type character(255), value boolean)")
connection.commit()
cursor.execute("create table if not exists Ultrasound (timestamp character(255), sensorId character(255), value integer)")
connection.commit()
# CREATE ACTUATOR DATABASE
cursor.execute("create table if not exists Actuator (actuatorId character(255), action character(255), extraData blob)")
connection.commit()

run(host='localhost', port=8080, debug=True)