// ================================
// GEOCALC — Frontend JavaScript
// Conecta con el backend Python/Flask
// ================================


// ---- 1. CONFIGURACIÓN DE FIGURAS ----
// Define qué campos necesita cada figura

const FIGURAS = {
  circulo: {
    campos: [
      { id: 'radio', label: 'radio', placeholder: 'ej: 5', tipo: 'number' }
    ]
  },
  rectangulo: {
    campos: [
      { id: 'base',   label: 'base',   placeholder: 'ej: 8', tipo: 'number' },
      { id: 'altura', label: 'altura', placeholder: 'ej: 5', tipo: 'number' }
    ]
  },
  triangulo: {
    campos: [
      { id: 'base',   label: 'base',   placeholder: 'ej: 6',  tipo: 'number' },
      { id: 'altura', label: 'altura', placeholder: 'ej: 4',  tipo: 'number' },
      { id: 'lado_a', label: 'lado a', placeholder: 'ej: 5',  tipo: 'number' },
      { id: 'lado_b', label: 'lado b', placeholder: 'ej: 5',  tipo: 'number' },
      { id: 'lado_c', label: 'lado c', placeholder: 'ej: 6',  tipo: 'number' }
    ]
  },
  hexagono: {
    campos: [
      { id: 'lado', label: 'lado', placeholder: 'ej: 4', tipo: 'number' }
    ]
  },
  cilindro: {
    campos: [
      { id: 'radio',  label: 'radio',  placeholder: 'ej: 3', tipo: 'number' },
      { id: 'altura', label: 'altura', placeholder: 'ej: 8', tipo: 'number' }
    ]
  },
  esfera: {
    campos: [
      { id: 'radio', label: 'radio', placeholder: 'ej: 5', tipo: 'number' }
    ]
  }
};


// ---- 2. ESTADO GLOBAL ----
let figuraActual = 'circulo';


// ---- 3. REFERENCIAS AL DOM ----
const btnsFigura   = document.querySelectorAll('.figura__btn');
const camposEl     = document.getElementById('campos');
const btnCalcular  = document.getElementById('btnCalcular');
const requestPrev  = document.getElementById('requestPreview');
const estadoInicial    = document.getElementById('estadoInicial');
const resultadoContenido = document.getElementById('resultadoContenido');


// ---- 4. RENDERIZAR CAMPOS DEL FORMULARIO ----

function renderizarCampos(figura) {
  const config = FIGURAS[figura];
  camposEl.innerHTML = '';

  config.campos.forEach(campo => {
    const grupo = document.createElement('div');
    grupo.className = 'campo__grupo';
    grupo.innerHTML = `
      <label for="${campo.id}">${campo.label}</label>
      <input
        type="${campo.tipo}"
        id="${campo.id}"
        placeholder="${campo.placeholder}"
        min="0.01"
        step="any"
      >
    `;
    camposEl.appendChild(grupo);
  });

  // Actualizar preview del request
  actualizarRequestPreview(figura);
}


// ---- 5. ACTUALIZAR PREVIEW DEL REQUEST ----

function actualizarRequestPreview(figura) {
  const config = FIGURAS[figura];
  const ejemplo = { figura };

  config.campos.forEach(campo => {
    const input = document.getElementById(campo.id);
    ejemplo[campo.id] = input?.value || `<${campo.label}>`;
  });

  requestPrev.textContent = JSON.stringify(ejemplo, null, 2);
}


// ---- 6. SELECTOR DE FIGURAS ----

btnsFigura.forEach(btn => {
  btn.addEventListener('click', () => {

    // Quitar activo de todos
    btnsFigura.forEach(b => b.classList.remove('activo'));

    // Activar el seleccionado
    btn.classList.add('activo');
    figuraActual = btn.dataset.figura;

    // Renderizar nuevos campos
    renderizarCampos(figuraActual);
  });
});


// ---- 7. ACTUALIZAR PREVIEW AL ESCRIBIR ----

camposEl.addEventListener('input', () => {
  actualizarRequestPreview(figuraActual);
});


// ---- 8. CALCULAR — llamada al backend Python ----

btnCalcular.addEventListener('click', async () => {

  // Recoger valores del formulario
  const config = FIGURAS[figuraActual];
  const datos = { figura: figuraActual };
  let valido = true;

  config.campos.forEach(campo => {
    const input = document.getElementById(campo.id);
    const valor = parseFloat(input?.value);

    if (!valor || valor <= 0) {
      valido = false;
      input.style.borderColor = '#EF4444';
      setTimeout(() => input.style.borderColor = '', 2000);
    } else {
      datos[campo.id] = valor;
    }
  });

  if (!valido) return;

  // Indicador de carga
  btnCalcular.textContent = 'Calculando...';
  btnCalcular.classList.add('cargando');

  try {
    // ---- FETCH AL BACKEND PYTHON ----
    // Aquí es donde JavaScript habla con Flask
    const response = await fetch('/calcular', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(datos)
      // Convertimos el objeto JS a texto JSON para enviarlo
    });

    // Convertimos la respuesta JSON de Python a objeto JS
    const resultado = await response.json();

    if (response.ok) {
      mostrarResultado(resultado);
    } else {
      alert(resultado.error || 'Error en el servidor');
    }

  } catch (error) {
    alert('No se pudo conectar con el servidor Python');
    console.error(error);
  } finally {
    btnCalcular.textContent = 'Calcular con Python →';
    btnCalcular.classList.remove('cargando');
  }
});


// ---- 9. MOSTRAR RESULTADOS ----

function mostrarResultado(data) {

  // Mostrar panel de resultados
  estadoInicial.style.display = 'none';
  resultadoContenido.style.display = 'flex';

  // Header
  document.getElementById('resIcono').textContent  = data.icono;
  document.getElementById('resNombre').textContent = data.figura;

  // Tipo (triángulo)
  const tipoEl = document.getElementById('resTipo');
  tipoEl.textContent = data.tipo ? `Triángulo ${data.tipo}` : '';

  // SVG de la figura
  dibujarFigura(data.figura, data.parametros);

  // Métricas
  const metricasGrid = document.getElementById('metricasGrid');
  metricasGrid.innerHTML = '';

  const metricas = [];
  if (data.area      !== undefined) metricas.push({ label: 'Área',          valor: data.area,         unidad: 'u²' });
  if (data.perimetro !== undefined) metricas.push({ label: 'Perímetro',     valor: data.perimetro,    unidad: 'u'  });
  if (data.volumen   !== undefined) metricas.push({ label: 'Volumen',       valor: data.volumen,      unidad: 'u³' });
  if (data.diagonal  !== undefined) metricas.push({ label: 'Diagonal',      valor: data.diagonal,     unidad: 'u'  });
  if (data.apotema   !== undefined) metricas.push({ label: 'Apotema',       valor: data.apotema,      unidad: 'u'  });
  if (data.area_lateral !== undefined) metricas.push({ label: 'Área lateral', valor: data.area_lateral, unidad: 'u²' });

  metricas.forEach(m => {
    const card = document.createElement('div');
    card.className = 'metrica__card';
    card.innerHTML = `
      <span class="metrica__valor">${m.valor}</span>
      <span class="metrica__label">${m.label} (${m.unidad})</span>
    `;
    metricasGrid.appendChild(card);
  });

  // Parámetros
  const parametrosEl = document.getElementById('parametrosLista');
  parametrosEl.innerHTML = '';
  Object.entries(data.parametros).forEach(([key, val]) => {
    const tag = document.createElement('span');
    tag.className = 'parametro__tag';
    tag.innerHTML = `${key}: <span>${val}</span>`;
    parametrosEl.appendChild(tag);
  });

  // Fórmulas
  const formulasEl = document.getElementById('formulasLista');
  formulasEl.innerHTML = '';

  const formulas = [];
  if (data.formula_area)       formulas.push({ tipo: 'Área',     formula: data.formula_area });
  if (data.formula_perimetro)  formulas.push({ tipo: 'Perímetro',formula: data.formula_perimetro });
  if (data.formula_volumen)    formulas.push({ tipo: 'Volumen',  formula: data.formula_volumen });

  formulas.forEach(f => {
    const item = document.createElement('div');
    item.className = 'formula__item';
    item.innerHTML = `<span>${f.tipo}</span>${f.formula}`;
    formulasEl.appendChild(item);
  });

  // Response del servidor
  document.getElementById('responsePreview').textContent =
    JSON.stringify(data, null, 2);
}


// ---- 10. DIBUJAR FIGURA EN SVG ----

function dibujarFigura(figura, params) {
  const svg = document.getElementById('figuraSVG');
  svg.innerHTML = '';

  const color    = '#10B981';
  const colorFill= 'rgba(16,185,129,0.08)';
  const stroke   = 2;

  switch (figura) {

    case 'Círculo': {
      const c = document.createElementNS('http://www.w3.org/2000/svg', 'circle');
      c.setAttribute('cx', '150');
      c.setAttribute('cy', '100');
      c.setAttribute('r', '80');
      c.setAttribute('fill', colorFill);
      c.setAttribute('stroke', color);
      c.setAttribute('stroke-width', stroke);
      svg.appendChild(c);

      // Radio
      const line = document.createElementNS('http://www.w3.org/2000/svg', 'line');
      line.setAttribute('x1', '150'); line.setAttribute('y1', '100');
      line.setAttribute('x2', '230'); line.setAttribute('y2', '100');
      line.setAttribute('stroke', color);
      line.setAttribute('stroke-width', '1');
      line.setAttribute('stroke-dasharray', '4');
      svg.appendChild(line);

      const text = document.createElementNS('http://www.w3.org/2000/svg', 'text');
      text.setAttribute('x', '185'); text.setAttribute('y', '93');
      text.setAttribute('fill', color);
      text.setAttribute('font-size', '11');
      text.setAttribute('font-family', 'JetBrains Mono');
      text.textContent = `r=${params['Radio']}`;
      svg.appendChild(text);
      break;
    }

    case 'Rectángulo': {
      const r = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
      r.setAttribute('x', '50'); r.setAttribute('y', '40');
      r.setAttribute('width', '200'); r.setAttribute('height', '120');
      r.setAttribute('fill', colorFill);
      r.setAttribute('stroke', color);
      r.setAttribute('stroke-width', stroke);
      r.setAttribute('rx', '2');
      svg.appendChild(r);

      const t1 = document.createElementNS('http://www.w3.org/2000/svg', 'text');
      t1.setAttribute('x', '145'); t1.setAttribute('y', '30');
      t1.setAttribute('fill', color); t1.setAttribute('font-size', '11');
      t1.setAttribute('font-family', 'JetBrains Mono');
      t1.setAttribute('text-anchor', 'middle');
      t1.textContent = `b=${params['Base']}`;
      svg.appendChild(t1);

      const t2 = document.createElementNS('http://www.w3.org/2000/svg', 'text');
      t2.setAttribute('x', '268'); t2.setAttribute('y', '105');
      t2.setAttribute('fill', color); t2.setAttribute('font-size', '11');
      t2.setAttribute('font-family', 'JetBrains Mono');
      t2.textContent = `h=${params['Altura']}`;
      svg.appendChild(t2);
      break;
    }

    case 'Triángulo': {
      const poly = document.createElementNS('http://www.w3.org/2000/svg', 'polygon');
      poly.setAttribute('points', '150,20 280,180 20,180');
      poly.setAttribute('fill', colorFill);
      poly.setAttribute('stroke', color);
      poly.setAttribute('stroke-width', stroke);
      svg.appendChild(poly);

      const t = document.createElementNS('http://www.w3.org/2000/svg', 'text');
      t.setAttribute('x', '150'); t.setAttribute('y', '195');
      t.setAttribute('fill', color); t.setAttribute('font-size', '11');
      t.setAttribute('font-family', 'JetBrains Mono');
      t.setAttribute('text-anchor', 'middle');
      t.textContent = `b=${params['Base']}`;
      svg.appendChild(t);
      break;
    }

    case 'Hexágono': {
      const cx = 150, cy = 100, r = 80;
      const puntos = [];
      for (let i = 0; i < 6; i++) {
        const ang = (Math.PI / 3) * i - Math.PI / 6;
        puntos.push(`${cx + r * Math.cos(ang)},${cy + r * Math.sin(ang)}`);
      }
      const poly = document.createElementNS('http://www.w3.org/2000/svg', 'polygon');
      poly.setAttribute('points', puntos.join(' '));
      poly.setAttribute('fill', colorFill);
      poly.setAttribute('stroke', color);
      poly.setAttribute('stroke-width', stroke);
      svg.appendChild(poly);
      break;
    }

    case 'Cilindro': {
      const elipseT = document.createElementNS('http://www.w3.org/2000/svg', 'ellipse');
      elipseT.setAttribute('cx','150'); elipseT.setAttribute('cy','50');
      elipseT.setAttribute('rx','100'); elipseT.setAttribute('ry','30');
      elipseT.setAttribute('fill', colorFill);
      elipseT.setAttribute('stroke', color);
      elipseT.setAttribute('stroke-width', stroke);
      svg.appendChild(elipseT);

      const rect = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
      rect.setAttribute('x','50'); rect.setAttribute('y','50');
      rect.setAttribute('width','200'); rect.setAttribute('height','110');
      rect.setAttribute('fill', colorFill);
      rect.setAttribute('stroke', color);
      rect.setAttribute('stroke-width', stroke);
      svg.appendChild(rect);

      const elipseB = document.createElementNS('http://www.w3.org/2000/svg', 'ellipse');
      elipseB.setAttribute('cx','150'); elipseB.setAttribute('cy','160');
      elipseB.setAttribute('rx','100'); elipseB.setAttribute('ry','30');
      elipseB.setAttribute('fill', colorFill);
      elipseB.setAttribute('stroke', color);
      elipseB.setAttribute('stroke-width', stroke);
      svg.appendChild(elipseB);
      break;
    }

    case 'Esfera': {
      const c = document.createElementNS('http://www.w3.org/2000/svg', 'circle');
      c.setAttribute('cx','150'); c.setAttribute('cy','100');
      c.setAttribute('r','85');
      c.setAttribute('fill', colorFill);
      c.setAttribute('stroke', color);
      c.setAttribute('stroke-width', stroke);
      svg.appendChild(c);

      const elipse = document.createElementNS('http://www.w3.org/2000/svg', 'ellipse');
      elipse.setAttribute('cx','150'); elipse.setAttribute('cy','100');
      elipse.setAttribute('rx','85'); elipse.setAttribute('ry','30');
      elipse.setAttribute('fill','none');
      elipse.setAttribute('stroke', color);
      elipse.setAttribute('stroke-width','1');
      elipse.setAttribute('stroke-dasharray','5');
      svg.appendChild(elipse);
      break;
    }
  }
}


// ---- 11. ARRANQUE ----
renderizarCampos(figuraActual);