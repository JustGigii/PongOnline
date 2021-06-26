from socket import *
import thread

clients = []
Left = 0
Right = 0
def clientHandler(c, addr):
    global clients
    num=0
    print clients
    print(addr, "is Connected")
    while True:
        (Command, Player) = c.recv(1024).split(',')

        if Command == 'Close':
                c.close()
        elif Command == 'GiveSide':
            global Right
            global Left
            if Right == 1:
                Left += 1
                print str(Left) + ' ' + str(Right)
                c.send('Left')
            else:
                Right += 1
                print str(Left) + ' ' + str(Right)
                c.send('Right')
        elif Command == 'up':
            print Command + ' ' + Player
            for client in clients:
                client.send('up,'+Player)
        elif Command == 'down':
            print Command + ' ' + Player
            for client in clients:
                client.send('down,'+Player)
        elif Command == 'stay':
            for client in clients:
                client.send('stay,'+Player)
        elif Command == 'start':
            if Right == 1 and Left == 1:
                c.send('True')
            else:
                c.send('False')


HOST = '192.168.1.141' 
PORT = 25565

s = socket(AF_INET, SOCK_STREAM)
s.bind((HOST, PORT))
s.listen(2)

while True:
    c, addr = s.accept()
    clients.append(c)
    thread.start_new_thread(clientHandler, (c, addr))

s.close()