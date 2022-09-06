# DAW_Project

## Componente
Login, Register, Order, Shoes, Shoe-detail

## Rute 
Rute fara parametru: /shoes, /order, /auth
Rute cu parametru: /detail/:id

## Servicii conectate la serverul .NET
Serviciul de login/register: services/account/data.service
Serviciul de afisare produse: services/product/product.service
Serviciul pentru cart: services/cart/cart.service

## Formulare 
Login, Register
Formular de filter (in pagina cu toate produsele) si formular pentru plasarea comenzii

## Metode de comunicare
Am folosit @Input, @Output pentru comunciarea dintre componentele parinte si copil (shoes - componenta parinte, start - componenta copil)
Prin servicii: Afisarea numelui utilizatorului in pagina cu produsele (prin serviciul data service), pastratea in memorie a cartului (prin cart service)

## Directiva
/shared/directives/hover-btn.directive

## Pipe
/shared/pipes/convert-character.pipe
/shared/pipes/format-email.pipe

### Register + Login + Guard (done)
