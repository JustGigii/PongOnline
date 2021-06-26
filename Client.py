import socket
client = socket.socket()
client.connect(("83.130.148.134", 25565))
client.send('GiveSide,null')
Side = client.recv(1024)
print (Side)
client.send('start,'+Side)
bol = client.recv(1024)
while bol != 'True':
    client.send('start,' + Side)
    bol = client.recv(1024)
print bol
client.send('down,'+Side)
while True:
    print client.recv(1024)