# ContactManager
CRUDowa aplikacja do zarządzania kontaktami

## Instalacja
1.Sklonuj repozytorium
2.W pliku appsettings.Development.json dodaj własny lokalny serwer sql, w którym zamieścisz bazę danych
Po sklonowaniu repozytorium i zainstalowaniu zależności należy uruchomić backend wczytując w terminalu ścieżkę API i uruchammiając komendę "dotnet run"(można też uruchomić za pomocą visual studio)
z kolei interfejs użytkownika zostanie uruchomiony po wczytaniu w terminalu ścieżki client i wydaniu polecenie "ng serve"

## Omówienie Folderów i klas

Controllers: 
Folder przechowywujący wszystkie klasy kontrolerów obsługujących zdarzenia w aplikacji.

BaseApiController
Bazowy kontroler z ustawionym prefixem dzeciczący po ControllerBase. Jego idea jest taka, że wszystkie pozostałe kontrolery dziedzicząc ten bazowy, nie będą musiały mieć ustawianego prefixu ścieżki.

AccountController
Kontroler do obługi Logowania i Rejestrowania. Do szyfrowania haseł zostal wykorzystany algorytm SHA512 a user po zalogowaniu nie jest bezpośrednio przechowywany w aplikacji, tylko jego token

ContactsController
Kontroler obsługujący wszystkie operacje na kontaktach w których skład wchodzi: pobieranie listy kontaktów, dodawanie nowego kontaktu, aktualizowanie isnitjącego kontaktu i usuwanie kontaktu

CategoriesController 
Służy do pobrania listy kategorii, aby móc wyświetlić je w interfejsie, dodatkowo istnieje opcja dodania nowej kategorii

Data: 
Folder zawierający implementację repozytoriów i kontekst bazodanowy

DataContext
Klasa w której za pomocą EntityFramework dodawane są kolejne tabele do bazy i ustalane są relacje między modelami i atrybutami.

ContactsRepository
Klasa reprezentujaąca repozytorium kontaktów. Są w niej opisane wszystkie metody do operacji z bazą danych na kontaktach

CategoryRepository
Klasa reprezentujące repozytorium kategorii. Istnieją w niej metody do wydobycia wszystkich kategorii i dodawania nowych kategorii

DTOs
Folder zawierający klasy DTO do operacji na obiektach modeli

Entites
Folder zawierający reprezentację wszystkich modeli używanych w projekcie

Helpers
Folder zawierający wszystkie przydatne klasy pomocnicze w projekcie

Interfaces:
Folder z interfejsami wszystkich serwisów i repozytoriów

Services:
Folder zawiera tylko jedną klasę TokenService, która zajmuje się generowaniem tokenu dla użytkownika który się loguje. Tokeny w tym projekcie składają się z 3 elementów:nagłówka,ładunku i podpisu.

Extensions:
Folder zawierający osobne klasy do opisania konfiguracji aplikacji, która normalnie zawarta jest w klasie Program.cs. Ułatwia to czytelność kodu i zachowuje w klasie startowej tylko najważniejsze infromacje o konfigurajci projektu
