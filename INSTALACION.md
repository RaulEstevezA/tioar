# Instalación y requisitos (ES)

Este documento explica cómo **instalar y probar** el juego *Tio AR* en un dispositivo móvil, y cómo **compilarlo** desde Unity si fuera necesario.

---

## Instalación rápida (APK)

Si solo quieres probar el juego en el móvil, descarga la última APK desde:

- [Releases](../../releases)

> Para que funcione correctamente, se necesita un dispositivo Android compatible con **ARCore** y permitir el uso de la **cámara**.

---

## Requisitos

### Dispositivo móvil
- Android con soporte **ARCore**
- Cámara funcional
- Espacio libre suficiente para instalar la APK

Si el dispositivo no es compatible con ARCore, la aplicación puede no abrir correctamente o no detectar superficies.

---

## Instalar la APK en Android

### 1) Descargar la APK
Descarga el archivo `.apk` desde:
- [Releases](../../releases)

---

### 2) Copiar la APK al móvil
Puedes hacerlo de varias formas:
- enviándola por correo
- usando Google Drive
- por cable USB
- por WhatsApp/Telegram (si el tamaño lo permite)

---

### 3) Permitir instalación desde orígenes desconocidos
En Android, normalmente al abrir una APK descargada se mostrará un aviso.

Pulsa en:
- **Permitir / Ajustes**
- Activa **Permitir instalaciones de esta fuente**

Esto depende del móvil, pero suele aparecer como:
- “Instalar aplicaciones desconocidas”
- “Permitir desde este origen”

---

### 4) Instalar y abrir
Una vez permitido:
- pulsa **Instalar**
- abre la app desde el icono del móvil

---

## Permisos necesarios

Al iniciar la app:
- Android pedirá permiso para usar la **cámara**
- Pulsa: **Permitir**

Sin permiso de cámara, el juego no puede funcionar (AR).

---

## Recomendación para probar el juego

- Prueba en un lugar con buena iluminación
- Apunta a superficies como:
  - suelo
  - mesa
  - paredes lisas

El juego detecta planos y necesita que la cámara “lea” el entorno.

---

## Problemas comunes

### La cámara se ve negra o no aparece AR
Revisa:
- que el dispositivo sea compatible con ARCore
- que la app tenga permiso de cámara
- que haya suficiente luz en el entorno

---

### El juego no detecta superficies
Suele ocurrir si:
- el entorno está oscuro
- no hay textura suficiente (pared completamente blanca)
- el móvil no soporta AR bien

---

## Compilar desde Unity (opcional)

Esta parte solo es necesaria si se quiere abrir el proyecto y generar la APK manualmente.

### Requisitos
- **Unity 6**
- Módulo de Android instalado desde Unity Hub:
  - Android Build Support
  - Android SDK & NDK Tools
  - OpenJDK

### Compilar APK
1) Abrir el proyecto en Unity
2) Ir a:
   `File → Build Settings`
3) Seleccionar **Android**
4) Pulsar **Switch Platform**
5) Pulsar **Build**
6) Instalar la APK generada en el móvil

---

## Nota importante sobre Vulkan
ARCore suele fallar si se usa Vulkan.

En Unity debe estar configurado:
- **OpenGLES3**
- Vulkan desactivado

(esto se configura en `Project Settings → Player → Graphics API`)

---

## Notas finales

- Este proyecto está pensado como entrega académica y demostración.
- Para una experiencia estable, se recomienda probar siempre en un dispositivo real.

[**Main**](README.md)
[**Documentación en español**](README_es.md)