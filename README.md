# Sensor DataViewer

The goal with this project was to build a simple application created by Visual Studio 2022 C# which reads continuously the sensor's temperature and humitidy values, which are
obtained from Raspberry Pi 5 device with a help of DHT22 sensor trough network protocol. The network protocoll in my case accept that any IPv4 ip adress with portnumber 5000 can
receive DHT22 sensor data from Raspberry PI 5 device The operating system of the device is Debian GNU/Linux 13 (trixie).

Reading the sensor's values and transfer data over network to Visual Studio C# application was done with help of python script. 
Visual Studio C# application show the sensor data in real time with help of two graphs. One for temperature and the ohter one for humitidy.

#### Requirements for this Visual Studio C# project.
- .NET 9.0
-  C# language version 13.0

**Schema.**

<img width="424" height="377" alt="image" src="https://github.com/user-attachments/assets/e0e1109f-902d-422b-a060-8d95ffe38958" />

Sensor DHT22's signal is connected to Rasepberry PI 5's pin 12 (GPIO 18) where it reads the temperature and humitidy from sensor. 
Operating voltage is 3.3V - 5.5V for the DHT 22 sensor.

<img width="348" height="295" alt="image" src="https://github.com/user-attachments/assets/65eeb19c-32bb-4942-a8b2-a9ab43b24d3d" />

**Contents of the pyhton script.**
```
import signal
import sys
import socket
import board
import adafruit_dht
import time
from threading import Timer

socketvalue = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
socketvalue.bind(('', 5000))
socketvalue.listen(3)
print('Server is now running.')
sensor =  adafruit_dht.DHT22(board.D18)

def value_control():
    temp = sensor.temperature
    hum = sensor.humidity
    currentData = 'Temperature: ' + str(temp) + ' Humitidy: ' + str(hum)
    clientsocket.send(bytes(currentData, "utf-8"))
    Timer(5, value_control).start()
try:
   while True:
      clientsocket, address = socketvalue.accept()
      print(f"Connection from {address} has been established.")
      value_control()
except KeyboardInterrupt:
    sys.exit(0)
```
I used python version 3.13.5 for this project.

**A picture of the application.**
<img width="1991" height="689" alt="image" src="https://github.com/user-attachments/assets/55333681-3d0a-46e8-8aba-ee775462d329" />
