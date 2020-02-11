# CarRental
## Wypo�yczalnia samochod�w

1. Lista pojazd�w do wypo�yczenia (dodawanie, edycja)
2. Lista klient�w wypozyczalni (dodawanie, edycja, usuwanie)
3. Lista pracownik�w (dodawanie, edycja, usuwanie)
4. Lista wypozyczen (dodawanie, edycja, usuwanie) + nie oddane na czas

________Tabele____________
Pojazd
id

marka
model
nr_rej
vin
opis
cena

Pracownik
id
nazwa
login
haslo

Klient
id
nazwa
adres
nr_tel
email

Wypozyczenie
id
klient_id
pojazd_id
wypozyczajacypracownik_id
data_od
data_do
zwrot
komentarz

Powi�zania:
wypozyczenie - pracownik
wypozyczenie - klient
wypozyczenie - pojazd



## Okna program

1. Okno glowne
1.1. Logowanie
1.2. Lista pojazdow
1.2.1. Lista pojazdow mozliwych do wypozyczenia
1.2.2. Dodawanie.edycja pojazdow
1.2.3. Usuwanie pojazdow (usuwa wszystkie dane lacznie z wypozyczeniami danego pojazdu)
1.3. Lista klientow
1.3.1. Lista klientow zarejestrowanych w systemie
1.3.2. Dodawanie/edycja klienta
1.3.3. Usuwanie klienta (usuwa wszystkie dane lacznie z wypozyczeniami pojazdow przez danego klienta)
1.4. Lista pracownikow wypozyczalni
1.4.1. Lista pracownikow mogacych wypozyczac pojazd
1.4.2. Dodawanie/edycja pracownikow
1.4.3. Usuwanie pracownikow
1.5. Lista wypozyczen pojazdow
1.5.1. Lista wypozyczen pojazdow z zaznaczeniem, czy pojazd wrocil na czas
1.5.2. Dodawanie/edycja wypozyczenia
1.5.3. Usuwanie wypozyczenia
1.6. Panel kontrolny (Informacje)
1.6.1. Ilo�c pojazd�w
1.6.2. Ilo�� wypo�yczonych pojazd�w
1.6.3. Ilo�� op�nie� w zwrocie pojazdu