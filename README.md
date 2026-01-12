Aplikacja do zarz¹dzania zamówieniami i magazynem z polskimi produktami spo¿ywczymi na rynku USA



1. Opis projektu

Aplikacja internetowa zosta³a wykonana w technologii ASP.NET Core MVC i s³u¿y do zarz¹dzania:
- produktami w magazynie,
- klientami hurtowni,
- zamówieniami sk³adanymi przez u¿ytkowników.

System umo¿liwia rozró¿nienie u¿ytkowników:
- zwyk³y u¿ytkownik – przegl¹danie danych i sk³adanie zamówieñ,
- administrator – pe³ne zarz¹dzanie danymi.



2. Wymagania systemowe

Do uruchomienia projektu wymagane s¹:
- Windows 10/11
- .NET SDK 7.0
- Visual Studio 2022
- SQL Server Express / LocalDB
- Przegl¹darka internetowa



3. Instalacja projektu

Krok 1 – pobranie projektu
1. Sklonowaæ repozytorium z GitHub:
git clone https://github.com/NorbertSychta/BazyDanychProjekt
lub pobraæ jako ZIP i rozpakowaæ.
2. Otworzyæ plik Projekt.sln w Visual Studio.


Krok 2 – konfiguracja bazy danych
Aplikacja korzysta z Entity Framework Core oraz SQL Server. 
£añcuch po³¹czenia znajduje siê w pliku appsettings.json.
Przyk³adowy connection string:
"ConnectionStrings": {
  "ApplicationDbContextConnection": "Server=(localdb)\\mssqllocaldb;Database=Projekt;Trusted_Connection=True;MultipleActiveResultSets=true"}


Krok 3 – migracje bazy danych
W konsoli Mened¿era Pakietów nale¿y wykonaæ:
Update-Database
Spowoduje to:
- utworzenie bazy danych,
- utworzenie tabel (Products, Customers, Orders, OrderItems, Identity).
Jeœli Update-Database nie zadzia³a wykonaj awaryjnie:
Add-Migration Init
Update-Database


Krok 4 – uruchomienie aplikacji
W Visual Studio klikn¹æ Run (HTTPS).
Aplikacja uruchomi siê pod adresem:
https://localhost:xxxx



4. U¿ytkownicy testowi

Administrator
- Email: admin@hurtownia.com
- Has³o: Admin123!

Administrator ma dostêp do:
- dodawania, edycji i usuwania produktów,
- zarz¹dzania klientami,
- przegl¹dania danych.

Zwyk³y u¿ytkownik
- mo¿e samodzielnie zarejestrowaæ konto przez formularz Register,
- ma dostêp do przegl¹dania danych i sk³adania zamówieñ,
- nie ma dostêpu do edycji i usuwania danych.



5. Opis dzia³ania aplikacji z punktu widzenia u¿ytkownika

Na stronie g³ównej znajduje siê menu:
- Home
- Products
- Customers
- Orders
- Login / Register

Zak³adka produkty
- Lista produktów dostêpnych w magazynie
- Administrator mo¿e:
  - dodawaæ nowe produkty,
  - edytowaæ dane,
  - usuwaæ produkty
- Zwyk³y u¿ytkownik mo¿e tylko przegl¹daæ dane

Zak³adka Klienci
- Lista klientów hurtowni
- Administrator zarz¹dza danymi klientów (CRUD)
- Zwyk³y u¿ytkownik ma dostêp tylko do przegl¹dania

Zak³adka Zamówienia
- Dostêpne tylko dla zalogowanych u¿ytkowników
- U¿ytkownik:
  - wybiera klienta,
  - wybiera produkt,
  - podaje iloœæ
- Po z³o¿eniu zamówienia:
  - tworzone jest zamówienie,
  - aktualizowany jest stan magazynowy produktu



6. API

Aplikacja udostêpnia REST API CRUD dla encji Product.
Endpoint:
/api/ProductsApi
Obs³ugiwane operacje:
- GET – pobranie listy produktów
- GET/{id} – pobranie produktu
- POST – dodanie produktu
- PUT/{id} – edycja produktu
- DELETE/{id} – usuniêcie produktu
Dane zwracane s¹ w formacie JSON.

7. Podsumowanie

Projekt spe³nia wszystkie wymagania:
- architektura MVC,
- Entity Framework + relacyjna baza danych,
- minimum 4 encje w relacjach,
- minimum 3 formularze z walidacj¹,
- autoryzacja u¿ytkowników (Admin/User),
- API CRUD,
- repozytorium GitHub z histori¹ commitów.
