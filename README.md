# ARDUINOPROXSYS

PROXSYS - PROXIMITY SYSTEM

It is a simple project which main task is to mesure range of sensor with our program and customized scale.
Just only by changing few lines in Arduino file, you can test others sensors. (It may require to change scale both in program and on the spot measurements)


The idea is based on create scale 2x2m (with graduation 2cm horizontally and 20cm vertical), which response with picture rendered by the program. Conducting measurements of sensor's range is presented in following steps:

1. Preparation of the scale.
2. Connection sensor with computer via bluetooth and declare in program value of Serial Port.
3. Set sensor in the middle of the outer edge of scale - on the middle of side with 2cm graduation.
4. Use box 10x10cm.
5. Step by step move the box on the scale and declare the position of it in the program (current position is displayed in the upper left corner).
6. Use MAP option to check if sensor can see the box.

There is also an option to save generated map of the range into txt file (it is required to specify the path of the file).


PROXSYS - PROXIMITY SYSTEM

Prosty projekt, którego zadaniem jest zbadanie kształtu i zasięgu widocznosci czujnika za pomocą dedykowanego programu i skali.
Poprzez zmiane tylko paru linii w kodzie Arduino, jest możliwym by przetestować inne czujniki. (Może się to wiązać z koniecznością zmiany skali zarówno w programie jak i na miejscu pomiarów)

Pomysł opiera się na stworzeniu skali 2x2m (z podziałką 2cm w poziomie i 20cm w pionie), odpowiadającej obrazowi renderowanemu przez program. Prowadzenie pomiarów zasięgu czujnika przedstawia się następująco:

1. Przygotowaniu odpowiedniej skali
2. Podłączeniu czujnika za pomocą bluetooth do komputera i podaniu w programie odpowiedniej wartości portu COM.
3. Ustawienie czujnika na środku zewnętrznej krawędzi skali, tzn. na środku boku zawierającego podziałkę 2cm).
4. Wykorzystanie pudełka 10x10cm.
5. Stopniowe przesuwanie pudełka po skali, z zaznaczeniem jego pozycji w programie (aktualna zadana pozycja wyświeltana jest w lewym górnym rogu).
6. Wybranie opcji MAP, aby program na podstawie zadanej pozycji mógł sprawdzić, czy pudełko jest widoczne dla czujnika.

Program pozwala również na zapis wygenerowanej mapy zasięgu do pliku tekstowego (należy wcześniej podać ścieżkę do pliku).
