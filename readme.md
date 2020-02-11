# CarRental
## Wypo�yczalnia samochod�w

1. Lista pojazd�w do wypo�yczenia (dodawanie, edycja)
2. Lista klient�w wypozyczalni (dodawanie, edycja, usuwanie)
3. Lista pracownik�w (dodawanie, edycja, usuwanie)
4. Lista wypozyczen (dodawanie, edycja, usuwanie) + nie oddane na czas

## Tabele
1. Pojazd
- id
- marka
- model
- nr_rej
- vin
- opis
- cena

2. Pracownik
- id
- nazwa
- login
- haslo

3. Klient
- id
- nazwa
- adres
- nr_tel
- email

4. Wypozyczenie
- id
- klient_id
- pojazd_id
- wypozyczajacypracownik_id
- data_od
- data_do
- zwrot
- komentarz

Powi�zania:
- wypozyczenie - pracownik
- wypozyczenie - klient
- wypozyczenie - pojazd



## Okna programu

1. Okno glowne
   - Logowanie
   - Lista pojazdow
     - Lista pojazdow mozliwych do wypozyczenia
     - Dodawanie.edycja pojazdow
     - Usuwanie pojazdow (usuwa wszystkie dane lacznie z wypozyczeniami danego pojazdu)

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