# Sensor DataViewer

The goal of this project was to develop a simple application using Visual Studio 2022 C# that continuously reads temperature and humidity data from a DHT22 sensor connected to a Raspberry Pi 5. 
The sensor data is transmitted over a network and displayed in real time by the Visual Studio C# application. 
In this implementation, the network service is configured to send DHT22 sensor data to any IPv4 address listening on port 5000. This allows the application to receive sensor readings from the Raspberry Pi 5 across a local network.

The Raspberry Pi 5 runs Debian GNU/Linux 13 (Trixie). A Python application is responsible for reading the DHT22 sensor values and transmitting the data over the network to the Visual Studio C# application. 
The Python source code is included in the Python folder within this project. The Visual Studio C# application displays the sensor data in real time using two graphs. One for temperature and the other one for humitidy. 
The Raspberry Pi 5 reads temperature and humidity values from the DHT22 sensor and transfers the data over the network to the Visual Studio C# application for real-time monitoring.

#### Visual Studio C# Project requirements
- .NET 9.0
-  C# language version 13.0

**Schema.**

<img width="424" height="377" alt="image" src="https://github.com/user-attachments/assets/e0e1109f-902d-422b-a060-8d95ffe38958" />

The DHT22 sensor's data pin is connected to pin 12 (GPIO 18) on the Raspberry Pi 5. GPIO 18 is used to read temperature and humidity measurements from the sensor.
The DHT22 sensor operates within a voltage range of 3.3 V to 5.5 V, making it compatible with the Raspberry Pi 5.

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

def valueControl():
    try:
       temp = sensor.temperature
       hum = sensor.humidity
       currentData = 'Temperature: ' + str(temp) + ' Humitidy: ' + str(hum)
       clientsocket.send(bytes(currentData, "utf-8"))
       Timer(5, valueControl).start()
    except RuntimeError as error:
       currentData = 'error'
       clientsocket.send(bytes(currentData, "utf-8"))
       print("Error: ", error.args[0])
try:
   while True:
      try:
         clientsocket, address = socketvalue.accept()
         print(f"Connection from {address} has been established.")
         valueControl()
      except RuntimeError as error:
         currentData = 'Error'
         clientsocket.send(bytes(currentData, "utf-8"))
         printprint("Error: ", error.args[0])
except KeyboardInterrupt:
    sys.exit(0)
except ValueError:
    raise ValueError("Client IP adress not detected raise ValueError") from None
```
I used python version 3.13.5 for this project.

**A picture of the application.**
<img width="1991" height="689" alt="image" src="https://github.com/user-attachments/assets/55333681-3d0a-46e8-8aba-ee775462d329" />
