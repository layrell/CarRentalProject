# System Wypo¿yczalni Samochodów

### Autorzy: Adam Ciesielski, Wojciech Czachurski

## 1. Opis Projektu
Aplikacja internetowa typu ASP.NET Core MVC s³u¿¹ca do kompleksowej obs³ugi wypo¿yczalni samochodów. System umo¿liwia przegl¹danie floty, rezerwacjê pojazdów z automatycznym wyliczaniem kosztów oraz zarz¹dzanie ofert¹ przez panel administratora.

## 2. Wykorzystane Technologie
* Jêzyk: C#
* Framework: ASP.NET Core 8.0 (MVC)
* Baza danych: Entity Framework Core + SQLite (plik app.db)
* Uwierzytelnianie: ASP.NET Core Identity
* Frontend: Razor Views, Bootstrap 5
* API: REST endpoint dla listy pojazdów

## 3. Funkcjonalnoœci

### Dla U¿ytkownika (Klient)
* Rejestracja i Logowanie: Bezpieczne zak³adanie konta z walidacj¹ danych.
* Przegl¹danie Oferty: Lista dostêpnych aut z podzia³em na marki, modele i ceny.
* Rezerwacja Pojazdu:
  * Wybór daty odbioru i zwrotu.
  * Walidacja dat - blokada wyboru daty wstecznej.
  * Automatyczne obliczanie ceny: System liczy pe³ne doby i mno¿y przez stawkê dzienn¹ auta.
* Panel Klienta: Podgl¹d historii w³asnych rezerwacji.
* Kontakt: Formularz kontaktowy wysy³aj¹cy wiadomoœci do bazy.

### Dla Administratora (Admin)
* Zarz¹dzanie Flot¹: Dodawanie i usuwanie samochodów z oferty.
* Role i Uprawnienia: Dostêp do funkcji edycji (Create, Delete) chroniony atrybutem [Authorize(Roles = "Admin")].
* Auto-Setup: Konto Administratora tworzy siê automatycznie przy pierwszym uruchomieniu aplikacji, jeœli nie istnieje.

## 4. Baza Danych (SQLite)
Projekt wykorzystuje podejœcie Code First. Baza danych jest przechowywana w lokalnym pliku app.db.
G³ówne tabele:
* Cars - Pojazdy.
* Categories - Kategorie pojazdów.
* Rentals - Rezerwacje.
* ContactMessages - Wiadomoœci z formularza.
* AspNetUsers - U¿ytkownicy i role systemowe.

Uwaga: Plik bazy danych nie jest przechowywany w repozytorium (jest ignorowany przez .gitignore). Baza tworzy siê automatycznie po wykonaniu instrukcji uruchomienia.

## 5. Instrukcja Uruchomienia

Aby uruchomiæ projekt na czystym œrodowisku:

1. Sklonuj repozytorium lub wypakuj projekt.
2. Otwórz terminal w folderze projektu.
3. Wykonaj migracjê bazy danych (utworzy to plik app.db):
   dotnet ef database update
4. Uruchom aplikacjê:
   dotnet run

Aplikacja uruchomi siê domyœlnie pod adresem localhost.

## 6. Dane Logowania

Przy pierwszym uruchomieniu system automatycznie tworzy konto Administratora oraz przyk³adowe samochody (mechanizm seedowania).

Konto Administratora:
* Email: admin@test.pl
* Has³o: Admin123!

Zwykli u¿ytkownicy mog¹ zak³adaæ konta samodzielnie poprzez formularz "Register".

## 7. API Endpoint
Aplikacja wystawia publiczny endpoint API zwracaj¹cy listê samochodów w formacie JSON:
* Adres: /api/cars/all
* Metoda: GET