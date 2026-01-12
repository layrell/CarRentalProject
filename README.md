# System Wypożyczalni Samochodów

### Autorzy: Adam Ciesielski, Wojciech Czachurski

## 1. Opis Projektu
Aplikacja internetowa typu ASP.NET Core MVC służąca do kompleksowej obsługi wypożyczalni samochodów. System umożliwia przeglądanie floty, rezerwację pojazdów z automatycznym wyliczaniem kosztów oraz zarządzanie ofertą przez konto administratora.

## 2. Wykorzystane Technologie
* Język: C#
* Framework: ASP.NET Core 8.0 (MVC)
* Baza danych: Entity Framework Core + SQLite (plik app.db)
* Uwierzytelnianie: ASP.NET Core Identity
* Frontend: Razor Views, Bootstrap 5
* API: REST endpoint dla listy pojazdów

## 3. Funkcjonalności

### Dla Użytkownika (Klient)
* Rejestracja i Logowanie: Bezpieczne zakładanie konta z walidacją danych.
* Przeglądanie Oferty: Lista dostępnych aut z podziałem na marki, modele i ceny.
* Rezerwacja Pojazdu:
  * Wybór daty odbioru i zwrotu.
  * Walidacja dat - blokada wyboru daty wstecznej.
  * Automatyczne obliczanie ceny: System liczy pełne doby i mnoży przez stawkę dzienną auta.
* Panel Klienta: Podgląd historii własnych rezerwacji.
* Kontakt: Formularz kontaktowy wysyłający wiadomości do bazy.

### Dla Administratora (Admin)
* Zarządzanie Flotą: Dodawanie i usuwanie samochodów z oferty.
* Role i Uprawnienia: Dostęp do funkcji edycji (Create, Delete) chroniony atrybutem [Authorize(Roles = "Admin")].
* Auto-Setup: Konto Administratora tworzy się automatycznie przy pierwszym uruchomieniu aplikacji, jeśli nie istnieje.

## 4. Baza Danych (SQLite)
Projekt wykorzystuje podejście Code First. Baza danych jest przechowywana w lokalnym pliku app.db.
Główne tabele:
* Cars - Pojazdy.
* Categories - Kategorie pojazdów.
* Rentals - Rezerwacje.
* ContactMessages - Wiadomości z formularza.
* AspNetUsers - Użytkownicy i role systemowe.

Uwaga: Plik bazy danych nie jest przechowywany w repozytorium (jest ignorowany przez .gitignore). Baza tworzy się automatycznie po wykonaniu instrukcji uruchomienia.

## 5. Instrukcja Uruchomienia

Aby uruchomić projekt na czystym środowisku:

1. Sklonuj repozytorium lub wypakuj projekt.
2. Otwórz terminal w folderze projektu.
3. Wykonaj migrację bazy danych (utworzy to plik app.db):
   dotnet ef database update
4. Uruchom aplikację:
   dotnet run

Aplikacja uruchomi się domyślnie pod adresem localhost.

## 6. Dane Logowania

Przy pierwszym uruchomieniu system automatycznie tworzy konto Administratora oraz przykładowe samochody (mechanizm seedowania).

Konto Administratora:
* Email: admin@test.pl
* Hasło: Admin123!

Zwykli użytkownicy mogą zakładać konta samodzielnie poprzez formularz "Register".

## 7. API Endpoint
Aplikacja wystawia publiczny endpoint API zwracający listę samochodów w formacie JSON:
* Adres: /api/cars/all
* Metoda: GET
