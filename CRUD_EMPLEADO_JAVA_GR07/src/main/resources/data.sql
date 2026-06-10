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
INSERT INTO XEPER_PERFI (XEPER_CODIGO, XEPER_DESCRI, XEPER_OBSERV)
VALUES ('ADMIN', 'Administrador', 'Perfil con acceso total al sistema');

-- 9. USUARIO ADMIN (contraseña: 123456)
-- NOTA: La contraseña debe ser un hash BCrypt. Reemplazar el hash de abajo
-- si se regenera. Hash generado para "123456":
INSERT INTO XEUSU_USUAR (PEEMP_CODIGO, XEUSU_PASWD, XEUSU_FECCRE,
                         XEUSU_PIEFIR, XEEST_CODIGO)
VALUES ('EMP00001',
        '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy',
        CURDATE(), 'Administrador del Sistema', 'A');
