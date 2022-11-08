# czysty_kod

Do odpalenia backendu potrzebujecie Visual Studio 2022. Community w zupełności wystarczy. Przy instalacji zwróćcie uwage czy macie zaznaczone .Net 6.0. (Domyślnie powinno być zaznaczone). 
Musicie postawić lokalnie bazę. Nazwijcie ją "eBlackGold" i stwórzcie dla użytkownika "user" z hasłem "password" (odznaczcie opcje zmiany hasła przy pierwszym logowaniu). Potem odpalcie skrypt który znajduje się w czysty_kod\CoalStore\CoalStore.DB\SchemaDB.
Skrypt powinien stworzyć tabele i nadać userowi ownera dla bazy "eBlackGold". Potem w visual studio wyszukajcie "DESKTOP-AMEVSG8" i zmieńcie wszystkie wystąpienia na nazwę instancji waszego serwera SQL. Nazwa instancji czyli jak odpalicie MSSQL to w object explorerze będzie ona na samej górze nad "Databases" i przed nawiasem. Potem zwyczajnie odpalacie projekt z visual studio.
Z poziomu endpointów można zrobić wszystko co było na screenach z frontu. Radzę zaczać od stworzenia suppliera i customera, potem dla suppliera mozna dodac produkty a na koncu robic ordery.
Praktycznie nie ma żadnych walidacji więc róbcie to z głową XD.