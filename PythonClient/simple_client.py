#!/usr/bin/python3

import Adafruit_DHT
import json
import requests

sensor = Adafruit_DHT.DHT22
pin = 23

base_url = "https://192.168.1.171:5001/api/sensorvalue"


# Try to grab a sensor reading.  Use the read_retry method which will retry up
# to 15 times to get a sensor reading (waiting 2 seconds between each retry).
humidity, temperature = Adafruit_DHT.read_retry(sensor, pin)

# Note that sometimes you won't get a reading and
# the results will be null (because Linux can't
# guarantee the timing of calls to read the sensor).
# If this happens try again!
if humidity is not None and temperature is not None:
    print('Temp={0:0.1f}*C  Humidity={1:0.1f}%'.format(temperature, humidity))

    data = {}
    data['SensorId'] = 1
    data['Value'] = round(temperature,2)
    data['ValueType'] = 1
    print(json.dumps(data))
    headers = {
    'content-type': 'application/json',
}
    response = requests.post(base_url, headers=headers, data=json.dumps(data),verify=False)
    print(response)
else:
    print('Failed to get reading. Try again!')
