const API_EMPLEADOS = window.location.origin + '/api/empleados';
const API_CARGOS = window.location.origin + '/api/cargos';
const API_FAMILIARES = window.location.origin + '/api/familiares';
let instanciaModal;
let instanciaModalFamiliar;
let cacheEmpleados = [];
let cacheFamiliares = [];
let cacheEditFamiliares = [];

document.addEventListener("DOMContentLoaded", () => {
    instanciaModal = new bootstrap.Modal(document.getElementById('modalEditar'));

    cargarComponentesAuxiliares();
    cargarEmpleados();

    document.getElementById('empFechaNac').setAttribute('max', restarAnios(new Date(), 18));
    document.getElementById('empFechaNac').setAttribute('min', restarAnios(new Date(), 100));

    document.getElementById('empDiscapacidad').addEventListener('change', (e) => {
        document.getElementById('lblDiscapacidad').textContent = e.target.checked ? "S\u00ed" : "No";
    });

    document.getElementById('editDiscapacidad').addEventListener('change', (e) => {
        document.getElementById('lblEditDiscap').textContent = e.target.checked ? "S\u00ed" : "No";
    });

    document.getElementById('empFoto').addEventListener('change', (e) => {
        const file = e.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = (ev) => {
                const img = document.getElementById('empPreviewFoto');
                img.src = ev.target.result;
                img.classList.remove('d-none');
            };
            reader.readAsDataURL(file);
        }
    });

    document.getElementById('editFoto').addEventListener('change', (e) => {
        const file = e.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = (ev) => {
                let img = document.getElementById('editPreviewFoto');
                if (!img) {
                    const container = e.target.closest('.card-body') || e.target.parentElement;
                    img = document.createElement('img');
                    img.id = 'editPreviewFoto';
                    img.className = 'img-fluid rounded border mb-3';
                    img.style.cssText = 'max-height: 200px; object-fit: cover; width: 100%;';
                    e.target.parentElement.insertBefore(img, e.target);
                }
                img.src = ev.target.result;
                img.classList.remove('d-none');
            };
            reader.readAsDataURL(file);
        }
    });

    document.getElementById('formEmpleado').addEventListener('submit', async (e) => {
        e.preventDefault();

        const cedula = document.getElementById('empCedula').value.trim();
        if (!validarCedulaEcuatoriana(cedula)) {
            mostrarAlerta("Error: El n\u00famero de c\u00e9dula ingresado es inv\u00e1lido en Ecuador.", "danger");
            return;
        }

        const telefono = document.getElementById('empTelefono').value.trim();
        if (telefono && (telefono.length !== 10 || isNaN(telefono))) {
            mostrarAlerta("Error: El tel\u00e9fono debe tener exactamente 10 d\u00edgitos.", "danger");
            return;
        }

        const nacimiento = document.getElementById('empFechaNac').value;
        const edad = calcularEdad(nacimiento);
        if (edad < 18 || edad > 100) {
            mostrarAlerta("Error: El empleado debe tener entre 18 y 100 a\u00f1os de edad.", "danger");
            return;
        }

        const cargoSeleccionado = document.getElementById('comboCargo').value;
        const usuPassword = document.getElementById('usuPassword').value;
        const usuPasswordConfirm = document.getElementById('usuPasswordConfirm').value;

        if (usuPassword || usuPasswordConfirm) {
            if (usuPassword.length < 4) {
                mostrarAlerta('La contrase\u00f1a debe tener al menos 4 caracteres.', 'danger');
                return;
            }
            if (usuPassword !== usuPasswordConfirm) {
                mostrarAlerta('Las contrase\u00f1as no coinciden.', 'danger');
                return;
            }
        }

        const fotoFile = document.getElementById('empFoto').files[0];
        const fotoBase64 = fotoFile ? await fileToBase64(fotoFile) : null;

        const payload = {
            nombres: document.getElementById('empNombres').value.trim(),
            apellidos: document.getElementById('empApellidos').value.trim(),
            cedula: cedula,
            fechaNacimiento: document.getElementById('empFechaNac').value,
            estadoCivil: { codigo: document.getElementById('empEstadoCivil').value },
            sexo: { codigo: document.getElementById('empSexo').value },
            discapacidad: document.getElementById('empDiscapacidad').checked,
            telefono: document.getElementById('empTelefono').value.trim(),
            correo: document.getElementById('empCorreo').value.trim(),
            direccion: document.getElementById('empDireccion').value.trim(),
            salario: parseFloat(document.getElementById('empSalario').value),
            fotoBase64: fotoBase64,
            superior: document.getElementById('comboSuperior').value ? { codigo: document.getElementById('comboSuperior').value } : null
        };

        const res = await fetch(`${API_EMPLEADOS}?cargoCodigo=${cargoSeleccionado}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });

        if (res.ok) {
            const empleadoGuardado = await res.json();
            document.getElementById('empCodigoGuardado').value = empleadoGuardado.codigo.trim();
            document.getElementById('empCodigoGuardadoDisplay').value = empleadoGuardado.codigo.trim() + ' - ' + empleadoGuardado.apellidos + ' ' + empleadoGuardado.nombres;

            if (usuPassword) {
                const resUsu = await fetch(`${API_EMPLEADOS}/${empleadoGuardado.codigo.trim()}/usuario`, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ password: usuPassword })
                });
                if (resUsu.ok) {
                    mostrarAlerta('\u00a1Empleado guardado y usuario creado exitosamente!', 'success');
                    document.getElementById('usuPassword').value = '';
                    document.getElementById('usuPasswordConfirm').value = '';
                } else {
                    mostrarAlerta('\u00a1Empleado guardado! Pero hubo un error al crear usuario: ' + (await resUsu.text()), 'warning');
                }
            } else {
                mostrarAlerta('\u00a1Empleado guardado exitosamente!', 'success');
            }
            cargarComponentesAuxiliares();
            cargarEmpleados();
        } else {
            mostrarAlerta(await res.text(), "danger");
        }
    });

    document.getElementById('inputBusqueda').addEventListener('input', filtrarTabla);

    document.querySelector('#tab-listado').addEventListener('shown.bs.tab', () => {
        cargarEmpleados();
    });

    instanciaModalFamiliar = new bootstrap.Modal(document.getElementById('modalEditarFamiliar'));

    document.getElementById('famFechaNac').setAttribute('max', hoyString());

    document.getElementById('btnGuardarFamiliar').addEventListener('click', async () => {

        const empleadoCodigo = document.getElementById('empCodigoGuardado').value;
        if (!empleadoCodigo) {
            mostrarAlerta("Debe guardar primero el empleado.", "danger");
            return;
        }

        const cedula = document.getElementById('famCedula').value.trim();
        if (!validarCedulaEcuatoriana(cedula)) {
            mostrarAlerta("Error: El n\u00famero de c\u00e9dula ingresado es inv\u00e1lido en Ecuador.", "danger");
            return;
        }

        const payload = {
            id: { codigoEmpleado: empleadoCodigo },
            cedula: cedula,
            nombres: document.getElementById('famNombres').value.trim(),
            apellidos: document.getElementById('famApellidos').value.trim(),
            fechaNacimiento: document.getElementById('famFechaNac').value,
            sexo: { codigo: document.getElementById('famSexo').value }
        };
        console.log("[CREAR FAMILIAR] Payload enviado:", JSON.stringify(payload));

        const res = await fetch(API_FAMILIARES, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });

        if (res.ok) {
            const guardado = await res.json();
            console.log("[CREAR FAMILIAR] Respuesta exitosa:", JSON.stringify(guardado));
            mostrarAlerta("\u00a1Familiar guardado exitosamente!", "success");
            document.getElementById('famCedula').value = '';
            document.getElementById('famNombres').value = '';
            document.getElementById('famApellidos').value = '';
            document.getElementById('famFechaNac').value = '';
            document.getElementById('famSexo').value = 'M';
            document.getElementById('famFechaNac').setAttribute('max', hoyString());
            cargarFamiliares(empleadoCodigo);
        } else {
            const texto = await res.text();
            console.error("[CREAR FAMILIAR] Error respuesta:", texto);
            mostrarAlerta("Error al guardar familiar: " + texto, "danger");
        }
    });

    document.querySelector('#tab-familiar').addEventListener('shown.bs.tab', () => {
        const codigo = document.getElementById('empCodigoGuardado').value;
        if (codigo) {
            document.getElementById('msgGuardarPrimero').classList.add('d-none');
            document.getElementById('panelFamiliaresEmpleado').classList.remove('d-none');
            cargarFamiliares(codigo);
        } else {
            document.getElementById('msgGuardarPrimero').classList.remove('d-none');
            document.getElementById('panelFamiliaresEmpleado').classList.add('d-none');
        }
    });


    document.getElementById('editFormFamiliar').addEventListener('submit', async (e) => {
        e.preventDefault();

        const empleadoCodigo = document.getElementById('editCodigo').value;
        if (!empleadoCodigo) {
            mostrarAlerta("Error: empleado no identificado.", "danger");
            return;
        }

        const cedula = document.getElementById('editFamCedulaNew').value.trim();
        if (!validarCedulaEcuatoriana(cedula)) {
            mostrarAlerta("Error: El n\u00famero de c\u00e9dula ingresado es inv\u00e1lido en Ecuador.", "danger");
            return;
        }

        const payload = {
            id: { codigoEmpleado: empleadoCodigo },
            cedula: cedula,
            nombres: document.getElementById('editFamNombresNew').value.trim(),
            apellidos: document.getElementById('editFamApellidosNew').value.trim(),
            fechaNacimiento: document.getElementById('editFamFechaNacNew').value,
            sexo: { codigo: document.getElementById('editFamSexoNew').value }
        };

        const res = await fetch(API_FAMILIARES, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });

        if (res.ok) {
            mostrarAlerta("\u00a1Familiar guardado exitosamente!", "success");
            document.getElementById('editFormFamiliar').reset();
            document.getElementById('editFamSexoNew').value = 'M';
            document.getElementById('editFamFechaNacNew').setAttribute('max', hoyString());
            cargarEditFamiliares(empleadoCodigo);
        } else {
            const texto = await res.text();
            mostrarAlerta("Error al guardar familiar: " + texto, "danger");
        }
    });

    document.querySelector('#edit-tab-familiar').addEventListener('shown.bs.tab', () => {
        const codigo = document.getElementById('editCodigo').value;
        if (codigo) {
            document.getElementById('editFamFechaNacNew').setAttribute('max', hoyString());
            cargarEditFamiliares(codigo);
        }
    });

    document.querySelector('#edit-tab-usuario').addEventListener('shown.bs.tab', () => {
        const codigo = document.getElementById('editCodigo').value;
        if (codigo) {
            cargarInfoUsuario(codigo);
        }
    });

    let editUsuEstadoActual = 'A';

    document.getElementById('btnToggleEstado').addEventListener('click', () => {
        const nuevoEstado = editUsuEstadoActual === 'A' ? 'I' : 'A';
        if (!confirm(`\u00bfEst\u00e1 seguro de ${nuevoEstado === 'I' ? 'desactivar' : 'activar'} este usuario?`)) return;

        const codigo = document.getElementById('editCodigo').value;
        fetch(`${API_EMPLEADOS}/${codigo}/usuario`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ estado: nuevoEstado })
        }).then(res => {
            if (res.ok) {
                mostrarAlerta(nuevoEstado === 'A' ? 'Usuario activado exitosamente.' : 'Usuario desactivado exitosamente.', 'success');
                cargarInfoUsuario(codigo);
            } else {
                res.text().then(t => mostrarAlerta(t, 'danger'));
            }
        });
    });

    document.getElementById('btnActualizarUsuario').addEventListener('click', async () => {
        const codigo = document.getElementById('editCodigo').value;
        const password = document.getElementById('editUsuPassword').value;
        const confirm = document.getElementById('editUsuPasswordConfirm').value;

        if (!password && !confirm) {
            mostrarAlerta('Debe ingresar una nueva contrase\u00f1a.', 'warning');
            return;
        }
        if (password !== confirm) {
            mostrarAlerta('Las contrase\u00f1as no coinciden.', 'danger');
            return;
        }
        if (password.length < 4) {
            mostrarAlerta('La contrase\u00f1a debe tener al menos 4 caracteres.', 'danger');
            return;
        }

        const res = await fetch(`${API_EMPLEADOS}/${codigo}/usuario`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ password })
        });

        if (res.ok) {
            mostrarAlerta('Contrase\u00f1a actualizada exitosamente.', 'success');
            document.getElementById('editUsuPassword').value = '';
            document.getElementById('editUsuPasswordConfirm').value = '';
        } else {
            mostrarAlerta(await res.text(), 'danger');
        }
    });
});

async function cargarComponentesAuxiliares() {
    try {
        const resC = await fetch(API_CARGOS);
        const cargos = await resC.json();
        const comboC = document.getElementById('comboCargo');
        comboC.innerHTML = '<option value="" selected disabled>Seleccione...</option>';
        cargos.forEach(c => comboC.innerHTML += `<option value="${c.codigo.trim()}">${c.nombre.trim()} - ${c.descripcion.trim()}</option>`);

        const resE = await fetch(API_EMPLEADOS);
        const emps = await resE.json();
        const comboS = document.getElementById('comboSuperior');
        comboS.innerHTML = '<option value="">-- Ninguno --</option>';
        emps.forEach(e => comboS.innerHTML += `<option value="${e.codigo.trim()}">${e.apellidos} ${e.nombres}</option>`);
    } catch (err) {
        console.error("Error al cargar cat\u00e1logos", err);
    }
}

async function cargarEmpleados() {
    try {
        const res = await fetch(API_EMPLEADOS);
        cacheEmpleados = await res.json();
        filtrarTabla();
    } catch (error) {
        console.error("Error al cargar empleados:", error);
    }
}

function filtrarTabla() {
    const busqueda = document.getElementById('inputBusqueda').value.toLowerCase().trim();
    const cuerpo = document.getElementById('tablaCuerpo');
    cuerpo.innerHTML = "";

    const filtrados = cacheEmpleados.filter(e => {
        if (!busqueda) return true;
        const ced = (e.cedula || '').toLowerCase();
        const nom = (e.nombres || '').toLowerCase();
        const ape = (e.apellidos || '').toLowerCase();
        const cod = (e.codigo || '').toLowerCase();
        return ced.includes(busqueda) || nom.includes(busqueda) || ape.includes(busqueda) || cod.includes(busqueda);
    });

    if (filtrados.length === 0) {
        cuerpo.innerHTML = `<tr><td colspan="6" class="text-center text-muted py-3">${busqueda ? 'No se encontraron empleados con ese criterio.' : 'No existen empleados registrados.'}</td></tr>`;
        return;
    }

    filtrados.forEach(e => {
        const cod = e.codigo ? e.codigo.trim() : '';
        const ced = e.cedula ? e.cedula.trim() : '';
        const nom = e.nombres ? e.nombres.trim() : '';
        const ape = e.apellidos ? e.apellidos.trim() : '';
        const sal = e.salario != null ? e.salario.toFixed(2) : '0.00';

        cuerpo.innerHTML += `
            <tr>
                <td class="fw-bold text-secondary small">${cod}</td>
                <td>${ced}</td>
                <td>${nom}</td>
                <td>${ape}</td>
                <td>$${sal}</td>
                <td class="text-center">
                    <button class="btn btn-sm btn-warning me-1 fw-semibold"
                        onclick="abrirModalEditar('${cod}')">
                        <i class="bi bi-pencil-fill"></i>
                    </button>
                    <button class="btn btn-sm btn-danger fw-semibold"
                        onclick="ejecutarEliminacion('${cod}')">
                        <i class="bi bi-trash-fill"></i>
                    </button>
                </td>
            </tr>
        `;
    });
}

function abrirModalEditar(codigo) {
    const emp = cacheEmpleados.find(e => e.codigo.trim() === codigo);
    if (!emp) return;

    document.getElementById('editCodigo').value = emp.codigo.trim();
    document.getElementById('editCodigoDisplay').value = emp.codigo.trim();
    document.getElementById('editCedula').value = emp.cedula ? emp.cedula.trim() : '';
    document.getElementById('editSalario').value = emp.salario;
    document.getElementById('editNombres').value = emp.nombres ? emp.nombres.trim() : '';
    document.getElementById('editApellidos').value = emp.apellidos ? emp.apellidos.trim() : '';
    document.getElementById('editTelefono').value = emp.telefono ? emp.telefono.trim() : '';
    document.getElementById('editCorreo').value = emp.correo ? emp.correo.trim() : '';
    document.getElementById('editDireccion').value = emp.direccion ? emp.direccion.trim() : '';
    document.getElementById('editEstadoCivil').value = emp.estadoCivil && emp.estadoCivil.codigo ? emp.estadoCivil.codigo.trim() : 'S';
    document.getElementById('editSexo').value = emp.sexo && emp.sexo.codigo ? emp.sexo.codigo.trim() : 'M';

    const discap = emp.discapacidad || false;
    document.getElementById('editDiscapacidad').checked = discap;
    document.getElementById('lblEditDiscap').textContent = discap ? "S\u00ed" : "No";

    const editPreview = document.getElementById('editPreviewFoto');
    editPreview.src = API_EMPLEADOS + '/' + emp.codigo.trim() + '/foto';
    editPreview.classList.remove('d-none');
    editPreview.onerror = function () { this.classList.add('d-none'); };

    cargarEditCombos(emp);

    document.getElementById('editFormFamiliar').reset();
    document.getElementById('editFamSexoNew').value = 'M';
    document.getElementById('editFamiliaresContainer').classList.add('d-none');
    document.getElementById('editTablaFamiliares').innerHTML = '';

    document.querySelector('#edit-tab-generales').click();
    instanciaModal.show();
}

async function cargarEditCombos(emp) {
    try {
        const resC = await fetch(API_CARGOS);
        const cargos = await resC.json();
        const comboCC = document.getElementById('editComboCargo');
        comboCC.innerHTML = '<option value="" selected disabled>Seleccione...</option>';
        cargos.forEach(c => comboCC.innerHTML += '<option value="' + c.codigo.trim() + '">' + c.nombre.trim() + ' - ' + c.descripcion.trim() + '</option>');

        const cargoActual = emp.asignaciones && emp.asignaciones.length > 0 ? emp.asignaciones[0].id.codigoCargo.trim() : '';
        if (cargoActual) comboCC.value = cargoActual;

        const resE = await fetch(API_EMPLEADOS);
        const emps = await resE.json();
        const comboS = document.getElementById('editComboSuperior');
        comboS.innerHTML = '<option value="">-- Ninguno --</option>';
        emps.forEach(e => comboS.innerHTML += '<option value="' + e.codigo.trim() + '">' + e.apellidos + ' ' + e.nombres + '</option>');

        if (emp.superior && emp.superior.codigo) {
            comboS.value = emp.superior.codigo.trim();
        }
    } catch (err) {
        console.error("Error al cargar combos de edici\u00f3n", err);
    }
}

async function cargarInfoUsuario(codigo) {
    try {
        const res = await fetch(`${API_EMPLEADOS}/${codigo}/usuario`);
        if (res.status === 404) {
            document.getElementById('editSinUsuarioContainer').classList.remove('d-none');
            document.getElementById('editPanelUsuarioContent').classList.add('d-none');
            return;
        }
        const data = await res.json();
        document.getElementById('editSinUsuarioContainer').classList.add('d-none');
        document.getElementById('editPanelUsuarioContent').classList.remove('d-none');
        document.getElementById('editUsuCodigoDisplay').value = data.id;

        editUsuEstadoActual = data.estado.codigo;
        const badge = document.getElementById('editUsuEstadoBadge');
        if (editUsuEstadoActual === 'A') {
            badge.className = 'badge fs-6 bg-success';
            badge.textContent = 'Activo';
        } else {
            badge.className = 'badge fs-6 bg-danger';
            badge.textContent = 'Inactivo';
        }
    } catch (e) {
        console.error('Error al cargar info de usuario:', e);
    }
}

document.getElementById('btnCrearUsuarioEdit').addEventListener('click', async () => {
    const codigo = document.getElementById('editCodigo').value;
    if (!codigo) return;
    const password = document.getElementById('editCrearUsuPassword').value;
    const confirm = document.getElementById('editCrearUsuPasswordConfirm').value;
    if (!password || password.length < 4) {
        mostrarAlerta('La contrase\u00f1a debe tener al menos 4 caracteres.', 'danger');
        return;
    }
    if (password !== confirm) {
        mostrarAlerta('Las contrase\u00f1as no coinciden.', 'danger');
        return;
    }
    const res = await fetch(`${API_EMPLEADOS}/${codigo}/usuario`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ password })
    });
    if (res.ok) {
        mostrarAlerta('Usuario creado exitosamente.', 'success');
        document.getElementById('editCrearUsuPassword').value = '';
        document.getElementById('editCrearUsuPasswordConfirm').value = '';
        cargarInfoUsuario(codigo);
    } else {
        mostrarAlerta(await res.text(), 'danger');
    }
});

async function guardarEdicion() {
    const codigo = document.getElementById('editCodigo').value.trim();

    const telefono = document.getElementById('editTelefono').value.trim();
    if (telefono && (telefono.length !== 10 || isNaN(telefono))) {
        mostrarAlerta("Error: El tel\u00e9fono debe tener exactamente 10 d\u00edgitos.", "danger");
        return;
    }

    const fotoFile = document.getElementById('editFoto').files[0];
    const fotoBase64 = fotoFile ? await fileToBase64(fotoFile) : null;

    const cargoCodigo = document.getElementById('editComboCargo').value;
    const superiorCodigo = document.getElementById('editComboSuperior').value;

    const payload = {
        salario: parseFloat(document.getElementById('editSalario').value),
        nombres: document.getElementById('editNombres').value.trim(),
        apellidos: document.getElementById('editApellidos').value.trim(),
        telefono: telefono,
        correo: document.getElementById('editCorreo').value.trim(),
        direccion: document.getElementById('editDireccion').value.trim(),
        estadoCivil: { codigo: document.getElementById('editEstadoCivil').value },
        discapacidad: document.getElementById('editDiscapacidad').checked,
        fotoBase64: fotoBase64,
        superior: superiorCodigo ? { codigo: superiorCodigo } : null
    };

    let url = `${API_EMPLEADOS}/${codigo}`;
    if (cargoCodigo) url += `?cargoCodigo=${encodeURIComponent(cargoCodigo)}`;

    const res = await fetch(url, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
    });

    if (res.ok) {
        instanciaModal.hide();
        mostrarAlerta("Empleado actualizado correctamente.", "success");
        cargarEmpleados();
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

async function ejecutarEliminacion(codigo) {
    if (!confirm(`\u00bfEst\u00e1 seguro de eliminar al empleado [${codigo}]?`)) return;

    const res = await fetch(`${API_EMPLEADOS}/${codigo}`, { method: 'DELETE' });
    if (res.ok) {
        mostrarAlerta("Empleado eliminado de la base de datos.", "success");
        cargarEmpleados();
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

function mostrarAlerta(mensaje, tipo) {
    const box = document.getElementById('alertGlobal');
    box.className = `alert alert-${tipo}`;
    box.textContent = mensaje;
    box.classList.remove('d-none');
    setTimeout(() => box.classList.add('d-none'), 4000);
}

function hoyString() {
    return new Date().toISOString().split('T')[0];
}

function restarAnios(fecha, anios) {
    const f = new Date(fecha);
    f.setFullYear(f.getFullYear() - anios);
    return f.toISOString().split('T')[0];
}

function calcularEdad(fechaNacimiento) {
    const hoy = new Date();
    const nac = new Date(fechaNacimiento);
    let edad = hoy.getFullYear() - nac.getFullYear();
    const mes = hoy.getMonth() - nac.getMonth();
    if (mes < 0 || (mes === 0 && hoy.getDate() < nac.getDate())) {
        edad--;
    }
    return edad;
}

function fileToBase64(file) {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = () => {
            const MAX = 800;
            let w = img.width, h = img.height;
            if (w > MAX || h > MAX) {
                const ratio = Math.min(MAX / w, MAX / h);
                w = Math.round(w * ratio);
                h = Math.round(h * ratio);
            }
            const canvas = document.createElement('canvas');
            canvas.width = w;
            canvas.height = h;
            const ctx = canvas.getContext('2d');
            ctx.drawImage(img, 0, 0, w, h);
            const base64 = canvas.toDataURL('image/jpeg', 0.7).split(',')[1];
            resolve(base64);
        };
        img.onerror = reject;
        img.src = URL.createObjectURL(file);
    });
}

async function cargarFamiliares(empleadoCodigo) {
    try {
        const res = await fetch(`${API_FAMILIARES}?empleadoCodigo=${empleadoCodigo}`);
        cacheFamiliares = await res.json();
        const container = document.getElementById('familiaresContainer');
        if (cacheFamiliares.length > 0) {
            container.classList.remove('d-none');
        } else {
            container.classList.add('d-none');
        }
        renderizarTablaFamiliares();
    } catch (error) {
        console.error("Error al cargar familiares:", error);
    }
}

function renderizarTablaFamiliares() {
    const cuerpo = document.getElementById('tablaFamiliares');
    cuerpo.innerHTML = "";

    if (cacheFamiliares.length === 0) {
        cuerpo.innerHTML = `<tr><td colspan="7" class="text-center text-muted py-3">No existen familiares registrados para este empleado.</td></tr>`;
        return;
    }

    cacheFamiliares.forEach(f => {
        const cod = f.id && f.id.codigo ? f.id.codigo.trim() : '';
        const empCod = f.id && f.id.codigoEmpleado ? f.id.codigoEmpleado.trim() : '';
        const ced = f.cedula ? f.cedula.trim() : '';
        const nom = f.nombres ? f.nombres.trim() : '';
        const ape = f.apellidos ? f.apellidos.trim() : '';
        const sexo = f.sexo && f.sexo.codigo ? (f.sexo.codigo.trim() === 'M' ? 'Masculino' : 'Femenino') : '';
        const fec = f.fechaNacimiento ? f.fechaNacimiento : '';

        cuerpo.innerHTML += `
            <tr>
                <td class="fw-bold text-secondary small">${cod}</td>
                <td>${ced}</td>
                <td>${nom}</td>
                <td>${ape}</td>
                <td>${sexo}</td>
                <td>${fec}</td>
                <td class="text-center">
                    <button class="btn btn-sm btn-warning me-1 fw-semibold"
                        onclick="abrirModalEditarFamiliar('${empCod}','${cod}')">
                        <i class="bi bi-pencil-fill"></i>
                    </button>
                    <button class="btn btn-sm btn-danger fw-semibold"
                        onclick="ejecutarEliminacionFamiliar('${empCod}','${cod}')">
                        <i class="bi bi-trash-fill"></i>
                    </button>
                </td>
            </tr>
        `;
    });
}

async function cargarEditFamiliares(empleadoCodigo) {
    try {
        const res = await fetch(`${API_FAMILIARES}?empleadoCodigo=${empleadoCodigo}`);
        cacheEditFamiliares = await res.json();
        const container = document.getElementById('editFamiliaresContainer');
        if (cacheEditFamiliares.length > 0) {
            container.classList.remove('d-none');
        } else {
            container.classList.add('d-none');
        }
        renderizarEditTablaFamiliares();
    } catch (error) {
        console.error("Error al cargar familiares:", error);
    }
}

function renderizarEditTablaFamiliares() {
    const cuerpo = document.getElementById('editTablaFamiliares');
    cuerpo.innerHTML = "";

    if (cacheEditFamiliares.length === 0) {
        cuerpo.innerHTML = `<tr><td colspan="7" class="text-center text-muted py-3">No existen familiares registrados para este empleado.</td></tr>`;
        return;
    }

    cacheEditFamiliares.forEach(f => {
        const cod = f.id && f.id.codigo ? f.id.codigo.trim() : '';
        const empCod = f.id && f.id.codigoEmpleado ? f.id.codigoEmpleado.trim() : '';
        const ced = f.cedula ? f.cedula.trim() : '';
        const nom = f.nombres ? f.nombres.trim() : '';
        const ape = f.apellidos ? f.apellidos.trim() : '';
        const sexo = f.sexo && f.sexo.codigo ? (f.sexo.codigo.trim() === 'M' ? 'Masculino' : 'Femenino') : '';
        const fec = f.fechaNacimiento ? f.fechaNacimiento : '';

        cuerpo.innerHTML += `
            <tr>
                <td class="fw-bold text-secondary small">${cod}</td>
                <td>${ced}</td>
                <td>${nom}</td>
                <td>${ape}</td>
                <td>${sexo}</td>
                <td>${fec}</td>
                <td class="text-center">
                    <button class="btn btn-sm btn-warning me-1 fw-semibold"
                        onclick="abrirModalEditarFamiliarEdit('${empCod}','${cod}')">
                        <i class="bi bi-pencil-fill"></i>
                    </button>
                    <button class="btn btn-sm btn-danger fw-semibold"
                        onclick="ejecutarEliminacionFamiliarEdit('${empCod}','${cod}')">
                        <i class="bi bi-trash-fill"></i>
                    </button>
                </td>
            </tr>
        `;
    });
}

function abrirModalEditarFamiliar(empleadoCodigo, codigo) {
    const fam = cacheFamiliares.find(f => f.id.codigo.trim() === codigo && f.id.codigoEmpleado.trim() === empleadoCodigo);
    if (!fam) return;

    document.getElementById('editFamCodigo').value = fam.id.codigo.trim();
    document.getElementById('editFamEmpleadoCodigo').value = fam.id.codigoEmpleado.trim();
    document.getElementById('editFamCedula').value = fam.cedula ? fam.cedula.trim() : '';
    document.getElementById('editFamNombres').value = fam.nombres ? fam.nombres.trim() : '';
    document.getElementById('editFamApellidos').value = fam.apellidos ? fam.apellidos.trim() : '';
    document.getElementById('editFamFechaNac').value = fam.fechaNacimiento ? fam.fechaNacimiento : '';
    document.getElementById('editFamSexo').value = fam.sexo && fam.sexo.codigo ? fam.sexo.codigo.trim() : 'M';

    instanciaModalFamiliar.show();
}

function abrirModalEditarFamiliarEdit(empleadoCodigo, codigo) {
    const fam = cacheEditFamiliares.find(f => f.id.codigo.trim() === codigo && f.id.codigoEmpleado.trim() === empleadoCodigo);
    if (!fam) return;

    document.getElementById('editFamCodigo').value = fam.id.codigo.trim();
    document.getElementById('editFamEmpleadoCodigo').value = fam.id.codigoEmpleado.trim();
    document.getElementById('editFamCedula').value = fam.cedula ? fam.cedula.trim() : '';
    document.getElementById('editFamNombres').value = fam.nombres ? fam.nombres.trim() : '';
    document.getElementById('editFamApellidos').value = fam.apellidos ? fam.apellidos.trim() : '';
    document.getElementById('editFamFechaNac').value = fam.fechaNacimiento ? fam.fechaNacimiento : '';
    document.getElementById('editFamSexo').value = fam.sexo && fam.sexo.codigo ? fam.sexo.codigo.trim() : 'M';

    instanciaModalFamiliar.show();
}

async function guardarEdicionFamiliar() {
    const empleadoCodigo = document.getElementById('editFamEmpleadoCodigo').value.trim();
    const codigo = document.getElementById('editFamCodigo').value.trim();

    const payload = {
        nombres: document.getElementById('editFamNombres').value.trim(),
        apellidos: document.getElementById('editFamApellidos').value.trim(),
        fechaNacimiento: document.getElementById('editFamFechaNac').value,
        sexo: { codigo: document.getElementById('editFamSexo').value }
    };

    const res = await fetch(`${API_FAMILIARES}/${empleadoCodigo}/${codigo}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
    });

    if (res.ok) {
        instanciaModalFamiliar.hide();
        mostrarAlerta("Familiar actualizado correctamente.", "success");
        cargarFamiliares(empleadoCodigo);
        cargarEditFamiliares(empleadoCodigo);
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

async function ejecutarEliminacionFamiliar(empleadoCodigo, codigo) {
    if (!confirm(`\u00bfEst\u00e1 seguro de eliminar al familiar [${codigo}]?`)) return;

    const res = await fetch(`${API_FAMILIARES}/${empleadoCodigo}/${codigo}`, { method: 'DELETE' });
    if (res.ok) {
        mostrarAlerta("Familiar eliminado de la base de datos.", "success");
        cargarFamiliares(empleadoCodigo);
        cargarEditFamiliares(empleadoCodigo);
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

async function ejecutarEliminacionFamiliarEdit(empleadoCodigo, codigo) {
    if (!confirm(`\u00bfEst\u00e1 seguro de eliminar al familiar [${codigo}]?`)) return;

    const res = await fetch(`${API_FAMILIARES}/${empleadoCodigo}/${codigo}`, { method: 'DELETE' });
    if (res.ok) {
        mostrarAlerta("Familiar eliminado de la base de datos.", "success");
        cargarEditFamiliares(empleadoCodigo);
        cargarFamiliares(empleadoCodigo);
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

function validarCedulaEcuatoriana(cedula) {
    if (cedula.length !== 10 || isNaN(cedula)) return false;
    const provincia = parseInt(cedula.substring(0, 2), 10);
    if (provincia < 1 || provincia > 24) return false;
    const coeficientes = [2, 1, 2, 1, 2, 1, 2, 1, 2];
    let suma = 0;
    for (let i = 0; i < 9; i++) {
        let det = parseInt(cedula.charAt(i), 10) * coeficientes[i];
        if (det >= 10) det -= 9;
        suma += det;
    }
    const verif = (Math.ceil(suma / 10) * 10) - suma;
    return verif === parseInt(cedula.charAt(9), 10) || (verif === 10 && cedula.charAt(9) === '0');
}
