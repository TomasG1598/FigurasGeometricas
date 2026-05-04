# ================================
# FIGURAS GEOMÉTRICAS — Backend
# Flask + Python · Tomás Gil Gómez
# ================================

from flask import Flask, render_template, request, jsonify
import math

# Flask es el framework web
# math nos da PI, raíz cuadrada, etc.

app = Flask(__name__)


# ---- CLASES DE FIGURAS ----
# Cada figura es una clase con sus propios cálculos

class Circulo:
    def __init__(self, radio):
        self.radio = radio

    def area(self):
        # π × r²
        return math.pi * self.radio ** 2

    def perimetro(self):
        # 2 × π × r
        return 2 * math.pi * self.radio

    def info(self):
        return {
            'figura': 'Círculo',
            'icono': '⬤',
            'parametros': {'Radio': self.radio},
            'area': round(self.area(), 4),
            'perimetro': round(self.perimetro(), 4),
            'formula_area': 'π × r²',
            'formula_perimetro': '2 × π × r'
        }


class Rectangulo:
    def __init__(self, base, altura):
        self.base = base
        self.altura = altura

    def area(self):
        return self.base * self.altura

    def perimetro(self):
        return 2 * (self.base + self.altura)

    def diagonal(self):
        return round(math.sqrt(self.base**2 + self.altura**2), 4)

    def info(self):
        return {
            'figura': 'Rectángulo',
            'icono': '▬',
            'parametros': {'Base': self.base, 'Altura': self.altura},
            'area': round(self.area(), 4),
            'perimetro': round(self.perimetro(), 4),
            'diagonal': self.diagonal(),
            'formula_area': 'base × altura',
            'formula_perimetro': '2 × (base + altura)'
        }


class Triangulo:
    def __init__(self, base, altura, lado_a, lado_b, lado_c):
        self.base   = base
        self.altura = altura
        self.lado_a = lado_a
        self.lado_b = lado_b
        self.lado_c = lado_c

    def area(self):
        return (self.base * self.altura) / 2

    def perimetro(self):
        return self.lado_a + self.lado_b + self.lado_c

    def tipo(self):
        lados = sorted([self.lado_a, self.lado_b, self.lado_c])
        if lados[0] == lados[1] == lados[2]:
            return 'Equilátero'
        elif lados[0] == lados[1] or lados[1] == lados[2]:
            return 'Isósceles'
        else:
            return 'Escaleno'

    def info(self):
        return {
            'figura': 'Triángulo',
            'icono': '▲',
            'parametros': {
                'Base': self.base,
                'Altura': self.altura,
                'Lado A': self.lado_a,
                'Lado B': self.lado_b,
                'Lado C': self.lado_c
            },
            'area': round(self.area(), 4),
            'perimetro': round(self.perimetro(), 4),
            'tipo': self.tipo(),
            'formula_area': '(base × altura) / 2',
            'formula_perimetro': 'lado_a + lado_b + lado_c'
        }


class Hexagono:
    def __init__(self, lado):
        self.lado = lado

    def area(self):
        # (3√3 / 2) × lado²
        return (3 * math.sqrt(3) / 2) * self.lado ** 2

    def perimetro(self):
        return 6 * self.lado

    def apotema(self):
        return round((math.sqrt(3) / 2) * self.lado, 4)

    def info(self):
        return {
            'figura': 'Hexágono',
            'icono': '⬡',
            'parametros': {'Lado': self.lado},
            'area': round(self.area(), 4),
            'perimetro': round(self.perimetro(), 4),
            'apotema': self.apotema(),
            'formula_area': '(3√3 / 2) × lado²',
            'formula_perimetro': '6 × lado'
        }


class Cilindro:
    def __init__(self, radio, altura):
        self.radio  = radio
        self.altura = altura

    def volumen(self):
        # π × r² × h
        return math.pi * self.radio ** 2 * self.altura

    def area_total(self):
        # 2π × r × (r + h)
        return 2 * math.pi * self.radio * (self.radio + self.altura)

    def area_lateral(self):
        return 2 * math.pi * self.radio * self.altura

    def info(self):
        return {
            'figura': 'Cilindro',
            'icono': '⬭',
            'parametros': {'Radio': self.radio, 'Altura': self.altura},
            'area': round(self.area_total(), 4),
            'volumen': round(self.volumen(), 4),
            'area_lateral': round(self.area_lateral(), 4),
            'formula_area': '2π × r × (r + h)',
            'formula_volumen': 'π × r² × h'
        }


class Esfera:
    def __init__(self, radio):
        self.radio = radio

    def volumen(self):
        # (4/3) × π × r³
        return (4/3) * math.pi * self.radio ** 3

    def area(self):
        # 4 × π × r²
        return 4 * math.pi * self.radio ** 2

    def info(self):
        return {
            'figura': 'Esfera',
            'icono': '●',
            'parametros': {'Radio': self.radio},
            'area': round(self.area(), 4),
            'volumen': round(self.volumen(), 4),
            'formula_area': '4 × π × r²',
            'formula_volumen': '(4/3) × π × r³'
        }


# ---- RUTAS ----
# Las rutas son las URLs que responde el servidor

@app.route('/')
def index():
    # Renderiza el HTML principal
    return render_template('index.html')


@app.route('/calcular', methods=['POST'])
def calcular():
    # Recibe los datos del formulario en formato JSON
    datos = request.get_json()
    figura = datos.get('figura')

    try:
        # Según la figura seleccionada, creamos el objeto y calculamos
        if figura == 'circulo':
            radio = float(datos['radio'])
            resultado = Circulo(radio).info()

        elif figura == 'rectangulo':
            base   = float(datos['base'])
            altura = float(datos['altura'])
            resultado = Rectangulo(base, altura).info()

        elif figura == 'triangulo':
            base   = float(datos['base'])
            altura = float(datos['altura'])
            lado_a = float(datos['lado_a'])
            lado_b = float(datos['lado_b'])
            lado_c = float(datos['lado_c'])
            resultado = Triangulo(base, altura, lado_a, lado_b, lado_c).info()

        elif figura == 'hexagono':
            lado = float(datos['lado'])
            resultado = Hexagono(lado).info()

        elif figura == 'cilindro':
            radio  = float(datos['radio'])
            altura = float(datos['altura'])
            resultado = Cilindro(radio, altura).info()

        elif figura == 'esfera':
            radio = float(datos['radio'])
            resultado = Esfera(radio).info()

        else:
            return jsonify({'error': 'Figura no reconocida'}), 400

        # Devolvemos el resultado en formato JSON al frontend
        return jsonify(resultado)

    except (ValueError, KeyError) as e:
        return jsonify({'error': 'Datos inválidos. Verifica los valores ingresados.'}), 400


# ---- ARRANQUE ----
if __name__ == '__main__':
    # debug=True permite ver errores detallados durante desarrollo
    app.run(debug=True)