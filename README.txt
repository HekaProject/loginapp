Baza de date este numita "heka", iar tabelul cu informatii despre utilizatori este numit "login".
Este structurat astfel:

ID - integer, auto-incremented
NAME - varchar(20)
PSWD - varchar(20)
ADMIN - boolean, default value 0

Trebuie intai deschisa baza de date prin XAMPP, apoi serverul node, si in final programul C#.
Pentru a rula serverul node, deschideti o consola in folderul ./Login/Node/ si rulati comanda "node server.js".