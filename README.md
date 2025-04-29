# Tankegang bag mine ædnringer
Jeg prøvede først at arbejde videre på den gamle MAUI app,
men der kom problemer med .gitignore og det hele blev fucked (typeshi).
Så jeg valgte bare at lave et helt nyt projekt fra bunden,
med ordentlig filstruktur og MVVM bindings sat rigtigt op.

NOTE: der skal stadig debugges, for der er nogle små fejl nogle steder.


## Struktur
### Projektet er delt op sådan her:

Data: POCO classes (models).

ViewModels: Al logik og bindings til views.

Views: Siderne (UI).

Services: Hjælpeklasser til database/backend kommunikation.

Interfaces: Bruges sammen med services for at holde tingene clean og fleksible.

Det hele er bygget for at være nemt at arbejde videre på.

## Fokusområder
MVVM overalt.

Services og interfaces for clean kode.

.gitignore sat rigtigt op, så der ikke er VS- eller temp-filer i Git (Ellers bliver det fucked igen).

Små, men gode commit messages så vi kan holde styr på tingene.

Husk fremover
Hold strukturen clean.

Snak sammen før større ændringer.

Lav små commits med klare beskeder.

Tjek .gitignore, hvis der kommer nye mapper.
