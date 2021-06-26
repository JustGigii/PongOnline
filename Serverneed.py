(Command, Player) = connection.recv(1024).split(',')
if (Command == 'Close'):
    connection.close()
    is_active = False
elif (Command == 'GiveSide'):
    connection.sendall('GiveSide')
    if (connection.recv(1024) == 'Right'):
        connection.send('Left')
    else:
        connection.send('Right')
if (Command == 'up'):
    print (Command)
    connection.sendall('up,' + Player)
if (Command == 'down'):
    connection.sendall('down,' + Player)





    import socket

    port = 25565
    ip = '83.130.148.134'
    Side = 'null'
    Client = socket.socket()
    Client.connect((ip, port))
    print 'conncet'
    Client.send('GiveSide,' + Side)
    while True:
        Answer = Client.recv(1024)
        if Answer == 'GiveSide':
            Client.send(Side)
        elif Answer == 'Left':
            Side = Answer
            print Side
            break
        elif Answer == 'Right':
            Side = Answer
            print Side
            break
    Client.sendall('down,' + Side)
    while True:
        print Client.recv(1024)
