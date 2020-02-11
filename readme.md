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

### Okno glowne
1. Logowanie
2. Lista pojazdow
   - Lista pojazdow mozliwych do wypozyczenia
   - Dodawanie.edycja pojazdow
   - Usuwanie pojazdow (usuwa wszystkie dane lacznie z wypozyczeniami danego pojazdu)
3. Lista klientow
   - Lista klientow zarejestrowanych w systemie
   - Dodawanie/edycja klienta
   - Usuwanie klienta (usuwa wszystkie dane lacznie z wypozyczeniami pojazdow przez danego klienta)
4. Lista pracownikow wypozyczalni
   - Lista pracownikow mogacych wypozyczac pojazd
   - Dodawanie/edycja pracownikow
   - Usuwanie pracownikow
5. Lista wypozyczen pojazdow
   - Lista wypozyczen pojazdow z zaznaczeniem, czy pojazd wrocil na czas
   - Dodawanie/edycja wypozyczenia
   - Usuwanie wypozyczenia
6. Panel kontrolny (Informacje)
   - Ilo�� pojazd�w
   - Ilo�� wypo�yczonych pojazd�w
   - Ilo�� op�nie� w zwrocie pojazdu