-- ============================================================
-- DATOS INICIALES OBLIGATORIOS - PROYECTO MONSTER
-- ============================================================
-- Estos datos deben existir siempre en la BD para el correcto
-- funcionamiento del sistema.
-- ============================================================

-- 1. SEXOS
INSERT INTO PESEX_SEXO (PESEX_CODIGO, PESEX_DESCRI) VALUES
('M', 'Masculino'),
('F', 'Femenino');

-- 2. ESTADOS CIVILES
INSERT INTO PEESC_ESTCIV (PEESC_CODIGO, PEESC_DESCRI) VALUES
('S', 'Soltero(a)'),
('C', 'Casado(a)'),
('V', 'Viudo(a)'),
('D', 'Divorciado(a)'),
('U', 'Unión Libre');

-- 3. ESTADOS DE USUARIO
INSERT INTO XEEST_ESTAD (XEEST_CODIGO, XEEST_DESCRI) VALUES
('A', 'Activo'),
('I', 'Inactivo');

-- 4. DEPARTAMENTO
INSERT INTO PEDEP_DEPAR (PEDEP_CODIGO, PEDEP_NOMBRE, PEDEP_DESCRI) VALUES
('DEP001', 'SIS', 'Sistemas');

-- 5. CARGO
INSERT INTO PECAR_CARGO (PECAR_CODIGO, PECAR_NOMBRE, PECAR_DESCRI, PEDEP_CODIGO) VALUES
('CAR001', 'ADM', 'Administrador del Sistema', 'DEP001');

-- 6. EMPLEADO ADMIN
INSERT INTO PEEMP_EMPLE (PEEMP_CODIGO, PEEMP_APELLI, PEEMP_NOMBRE, PEEMP_FECNAC,
                         PEEMP_DIREC, PEEMP_TELEF, PEEMP_EMAIL, PEEMP_CEDULA,
                         PEEMP_DISCAP, PEEMP_SALARI, PESEX_CODIGO)
VALUES ('EMP00001', 'Del Sistema', 'Administrador', CURDATE(),
        'Matriz', '0999999999', 'admin@monster.edu.ec', '1722222222',
        false, 800.00, 'M');

-- 7. ASIGNACION CARGO DEL EMPLEADO ADMIN
INSERT INTO PEASIG_ASIGNA (PEEMP_CODIGO, PECAR_CODIGO, PEASIG_FECINI)
VALUES ('EMP00001', 'CAR001', CURDATE());

-- 8. PERFIL ADMIN
INSERT INTO XEPER_PERFI (XEPER_CODIGO, XEPER_NOMBRE, XEPER_DESCRI, XEPER_OBSERV)
VALUES ('PER001', 'ADM', 'Administrador', 'Perfil con acceso total al sistema');

-- 9. SISTEMAS
INSERT INTO XESIS_SISTE (XESIS_CODIGO, XESIS_DESCRI) VALUES
('F', 'Finanzas'),
('X', 'Seguridad'),
('P', 'Personal'),
('G', 'Gestión de Proyectos');

-- 10. OPCIONES POR SISTEMA (PADRES E HIJOS)
-- ==================== Sistema Personal (P) ====================
-- Módulo padres
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO) VALUES
('P01', 'Gestionar Departamentos', 'P'),
('P02', 'Gestionar Cargos', 'P'),
('P03', 'Gestionar Empleados', 'P'),
('P04', 'Gestionar Familiares', 'P');

-- Hijos de P001 - Gestionar Departamentos
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('P11', 'CREAR departamento', 'P', 'P01'),
('P12', 'ACTUALIZAR departamento', 'P', 'P01'),
('P13', 'LISTAR departamento', 'P', 'P01'),
('P14', 'ELIMINAR departamento', 'P', 'P01');

-- Hijos de P002 - Gestionar Cargos
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('P21', 'CREAR cargo', 'P', 'P02'),
('P22', 'ACTUALIZAR cargo', 'P', 'P02'),
('P23', 'LISTAR cargo', 'P', 'P02'),
('P24', 'ELIMINAR cargo', 'P', 'P02');

-- Hijos de P003 - Gestionar Empleados
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('P31', 'CREAR empleado', 'P', 'P03'),
('P32', 'ACTUALIZAR empleado', 'P', 'P03'),
('P33', 'LISTAR empleado', 'P', 'P03'),
('P34', 'ELIMINAR empleado', 'P', 'P03');

-- Hijos de P004 - Gestionar Familiares
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('P41', 'CREAR familiar', 'P', 'P04'),
('P42', 'ACTUALIZAR familiar', 'P', 'P04'),
('P43', 'LISTAR familiar', 'P', 'P04'),
('P44', 'ELIMINAR familiar', 'P', 'P04');

-- ==================== Sistema Gestión de Proyectos (G) ====================
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO) VALUES
('G01', 'Gestionar Proyectos', 'G'),
('G02', 'Gestionar Tareas', 'G'),
('G03', 'Gestionar Asignaciones', 'G');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('G11', 'CREAR proyecto', 'G', 'G01'),
('G12', 'ACTUALIZAR proyecto', 'G', 'G01'),
('G13', 'LISTAR proyecto', 'G', 'G01'),
('G14', 'ELIMINAR proyecto', 'G', 'G01');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('G21', 'CREAR tarea', 'G', 'G02'),
('G22', 'ACTUALIZAR tarea', 'G', 'G02'),
('G23', 'LISTAR tarea', 'G', 'G02'),
('G24', 'ELIMINAR tarea', 'G', 'G02');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('G31', 'CREAR asignación', 'G', 'G03'),
('G32', 'ACTUALIZAR asignación', 'G', 'G03'),
('G33', 'LISTAR asignación', 'G', 'G03'),
('G34', 'ELIMINAR asignación', 'G', 'G03');

-- ==================== Sistema Finanzas (F) ====================
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO) VALUES
('F01', 'Gestionar Facturación', 'F'),
('F02', 'Gestionar Presupuestos', 'F'),
('F03', 'Gestionar Reportes Financieros', 'F');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('F11', 'CREAR factura', 'F', 'F01'),
('F12', 'ACTUALIZAR factura', 'F', 'F01'),
('F13', 'LISTAR factura', 'F', 'F01'),
('F14', 'ELIMINAR factura', 'F', 'F01');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('F21', 'CREAR presupuesto', 'F', 'F02'),
('F22', 'ACTUALIZAR presupuesto', 'F', 'F02'),
('F23', 'LISTAR presupuesto', 'F', 'F02'),
('F24', 'ELIMINAR presupuesto', 'F', 'F02');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('F31', 'CREAR reporte financiero', 'F', 'F03'),
('F32', 'ACTUALIZAR reporte financiero', 'F', 'F03'),
('F33', 'LISTAR reporte financiero', 'F', 'F03'),
('F34', 'ELIMINAR reporte financiero', 'F', 'F03');

-- ==================== Sistema Seguridad (X) ====================
INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO) VALUES
('X01', 'Gestionar Perfiles', 'X'),
('X02', 'Gestionar Asignar Perfiles', 'X'),
('X03', 'Gestionar Opciones por Perfil', 'X'),
('X04', 'Gestionar Usuarios', 'X');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('X11', 'CREAR perfil', 'X', 'X01'),
('X12', 'ACTUALIZAR perfil', 'X', 'X01'),
('X13', 'LISTAR perfil', 'X', 'X01'),
('X14', 'ELIMINAR perfil', 'X', 'X01');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('X21', 'CREAR asignación perfil', 'X', 'X02'),
('X22', 'ACTUALIZAR asignación perfil', 'X', 'X02'),
('X23', 'LISTAR asignación perfil', 'X', 'X02'),
('X24', 'ELIMINAR asignación perfil', 'X', 'X02');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('X31', 'CREAR opción perfil', 'X', 'X03'),
('X32', 'ACTUALIZAR opción perfil', 'X', 'X03'),
('X33', 'LISTAR opción perfil', 'X', 'X03'),
('X34', 'ELIMINAR opción perfil', 'X', 'X03');

INSERT INTO XEOPC_OPCIO (XEOPC_CODIGO, XEOPC_DESCRI, XESIS_CODIGO, XEOPC_PADRE) VALUES
('X41', 'CREAR usuario', 'X', 'X04'),
('X42', 'ACTUALIZAR usuario', 'X', 'X04'),
('X43', 'LISTAR usuario', 'X', 'X04'),
('X44', 'ELIMINAR usuario', 'X', 'X04');

-- 11. ASIGNAR TODAS LAS OPCIONES HIJO AL PERFIL ADMIN (PER001)
INSERT INTO XEOXP_OPCPE (XEOPC_CODIGO, XEPER_CODIGO, XEOXP_FECASI)
SELECT o.XEOPC_CODIGO, 'PER001', CURDATE()
FROM XEOPC_OPCIO o
WHERE o.XEOPC_PADRE IS NOT NULL;

-- 12. USUARIO ADMIN (contraseña: 123456)
-- NOTA: La contraseña debe ser un hash BCrypt. Reemplazar el hash de abajo
-- si se regenera. Hash generado para "123456":
INSERT INTO XEUSU_USUAR (PEEMP_CODIGO, XEUSU_PASWD, XEUSU_FECCRE,
                         XEUSU_PIEFIR, XEEST_CODIGO)
VALUES ('EMP00001',
        '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy',
        CURDATE(), 'Administrador del Sistema', 'A');
