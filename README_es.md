# Tio AR — Documentación extendida (ES)

Este documento contiene la documentación extendida del proyecto **Tio AR**, desarrollado por el equipo **UOC Gamers**.

---

## Resumen del proyecto

**Tio AR** es un mini-juego para móviles basado en **Realidad Aumentada (AR)**, desarrollado con **Unity 6** utilizando **XR / AR Foundation**.  
El objetivo del jugador es localizar al **Tió** en el entorno real y golpearlo el mayor número de veces posible antes de que se acabe el tiempo.

El juego se estructura en **3 rondas**, cada una con un tiempo distinto. La puntuación se acumula de forma global y se muestra al final.

---

## Bucle de juego

El juego se compone de tres rondas consecutivas.

### Estructura de cada ronda
Cada ronda tiene dos fases:

1) **Fase de búsqueda**
- Se muestra el mensaje **"Busca al Tió"**
- Duración: **5 segundos**
- Este tiempo **NO cuenta** para el temporizador de la ronda
- Sirve para que el jugador escanee el entorno y se detecten superficies

2) **Fase de golpeo**
- El Tió aparece en una **posición aleatoria** en el espacio AR
- Se muestra el mensaje: **"¡Golpea al Tió!"**
- Se inicia el temporizador de la ronda (tiempo distinto según ronda)
- Cada golpe válido suma **+1 punto**

Cuando termina una ronda:
- El temporizador llega a 0
- Se destruye el Tió actual
- Comienza automáticamente la siguiente ronda

### Tiempos de ronda
Los tiempos se configuran desde el script `GameManagerAR` mediante un array editable (desde el Inspector):

- Ronda 1: **10 segundos**
- Ronda 2: **8 segundos**
- Ronda 3: **4 segundos**

> Nota: estos valores se pueden modificar fácilmente.

---

## Sistema AR (XR / AR Foundation)

El proyecto utiliza el sistema XR/AR de Unity:

- Se activa la **detección de planos** para reconocer superficies del entorno
- La visualización de planos (rejillas/círculos tipo “debug”) puede desactivarse sin afectar al juego
- El Tió se genera frente al jugador aplicando un offset aleatorio respecto a la cámara

### Lógica de aparición del Tió (Spawn)
El Tió aparece con un desplazamiento aleatorio respecto a la cámara:

- Distancia frontal: entre 4 y 6 unidades
- Desplazamiento lateral: entre -2 y 2 unidades

Esto hace que el objetivo sea visible y que no aparezca siempre en el mismo sitio.

---

## Sistema de interfaz (UI)

La interfaz se ha implementado con **Canvas + TextMeshPro**.

### HUD (durante el juego)
Durante las rondas se muestran:
- **TimeText** → tiempo restante
- **ScoreText** → puntuación total

### Mensajes temporizados
Mensajes que aparecen automáticamente:
- **SearchMessage** → "Busca al Tió" (5 s)
- **HitMessage** → "¡Golpea al Tió!" (mensaje corto antes de iniciar el temporizador)

### Pantalla inicial
El juego comienza con un panel inicial que incluye:
- botón de empezar
- botón/icono de audio (activar/desactivar sonido)

La partida no empieza hasta pulsar **Start**.

### Pantalla final
Después de la ronda 3:
- se muestra el panel final
- aparece la puntuación total
- existe un botón para reiniciar la partida

---

## Sistema de audio

El proyecto incluye:
- música de fondo
- efectos de golpe (4 variaciones aleatorias)
- botón general para activar/desactivar sonido

### Activar / desactivar sonido
El audio global se controla mediante:

- `AudioListener.volume = 1f` (sonido activado)
- `AudioListener.volume = 0f` (sonido desactivado)

El icono del botón cambia dependiendo del estado actual.

### Sonido de golpe aleatorio
Cada vez que el jugador golpea al Tió:
- se selecciona uno de los 4 sonidos de golpe al azar
- se reproduce con `PlayOneShot()` para evitar cortes

---

## Interacción táctil (detección de golpes)

La detección de toques se realiza usando el sistema de eventos de Unity (touch/click):

### Componentes necesarios
- El prefab del Tió tiene un **Box Collider**
- La cámara principal tiene un **Physics Raycaster**
- La escena tiene un **EventSystem**

### Comportamiento
Al tocar el Tió:
- se registra el golpe solo si la ronda está activa
- se suma +1 punto
- suena un golpe aleatorio

---

## Scripts principales

### `GameManagerAR`
Controla todo el flujo:
- rondas y tiempos
- aparición y destrucción del objetivo
- actualización de UI
- pantalla final
- reinicio de partida

### `SearchMessage`
Muestra el mensaje "Busca al Tió" durante un tiempo fijo.

### `TimedMessage`
Componente reutilizable para mostrar un mensaje durante un tiempo determinado (se usa para "¡Golpea al Tió!").

### `SoundToggleButton`
Gestiona:
- activar/desactivar sonido
- cambio de icono
- actualización del volumen global con `AudioListener`

### `TioHitSound`
Reproduce un sonido aleatorio de golpe cuando el jugador toca al objetivo.

---

## Notas de compilación (APK)

- Plataforma: **Android**
- Requiere un dispositivo compatible con **ARCore**
- Es necesaria la autorización de cámara para funcionamiento AR

---

## Limitaciones conocidas

- El módulo AR se entrega por separado de la parte 2D y 3D debido a problemas de integración y estabilidad en una única build
- La aparición del Tió se calcula respecto a la cámara (spawn aleatorio), sin necesidad de selección avanzada de plano para esta versión

---

## Créditos

Proyecto desarrollado por el equipo **UOC Gamers**:

- Aleix Ortiz
- Carlos Ruz
- Jordi Montserrat
- Raul Estevez
- Roger Mohino


[**Main**](README.md)

[**Instalación y requisitos (Español)**](SETUP.md)