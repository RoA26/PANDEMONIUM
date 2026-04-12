anio_actual = 2025
nombre = input("¿Cual es tu nombre? ")
anio_nacimiento = int(input("¿En que año naciste?"))
edad = anio_actual - anio_nacimiento
print(f"Hola {nombre}, tienes {edad} años.")

if  edad >= 60:
    print("Usted ya esta viejito")
elif edad >= 18:
    print("Eres mayor de edad")
else:
    print("Eres menor de edad")
    
