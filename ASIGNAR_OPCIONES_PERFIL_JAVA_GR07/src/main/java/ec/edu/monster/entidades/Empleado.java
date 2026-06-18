package ec.edu.monster.entidades;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import lombok.Data;

@Data
@Entity
@Table(name = "PEEMP_EMPLE")
public class Empleado implements Serializable {
    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "PEEMP_CODIGO", columnDefinition = "CHAR(8)", length = 8)
    private String codigo;
    
    @Column(name = "PEEMP_APELLI", nullable = false, length = 50)
    private String apellidos;
    
    @Column(name = "PEEMP_NOMBRE", nullable = false, length = 50)
    private String nombres;

    @Temporal(TemporalType.DATE)
    @Column(name = "PEEMP_FECNAC", nullable = false, columnDefinition = "DATE")
    private Date fechaNacimiento;
    
    @Column(name = "PEEMP_DIREC", length = 200)
    private String direccion;
    
    @Column(name = "PEEMP_TELEF", length = 15)
    private String telefono;
    
    @Column(name = "PEEMP_EMAIL", nullable = false, length = 100)
    private String correo;
    
    @Column(name = "PEEMP_CEDULA", length = 10, unique = true)
    private String cedula;
    
    @Column(name = "PEEMP_DISCAP", nullable = false)
    private boolean discapacidad;
    
    @Column(name = "PEEMP_SALARI", nullable = false, columnDefinition = "FLOAT(7,2)")
    private float salario;

    @JsonIgnore
    @Lob
    @Column(name = "PEEMP_FOTO", columnDefinition = "MEDIUMBLOB")
    private byte[] foto;

    @Transient
    private String fotoBase64;

    @ManyToOne
    @JoinColumn(name = "PEEMP_SUPERIOR", referencedColumnName = "PEEMP_CODIGO")
    @JsonIgnoreProperties({"asignaciones", "superior"})
    private Empleado superior;

    @OneToMany(mappedBy = "empleado", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.EAGER)
    @JsonIgnoreProperties("empleado")
    private List<AsignacionCargo> asignaciones = new ArrayList<>();

    @ManyToOne
    @JoinColumn(name = "PEESC_CODIGO", referencedColumnName = "PEESC_CODIGO")
    @JsonIgnoreProperties("empleados")
    private EstadoCivil estadoCivil;

    @ManyToOne
    @JoinColumn(name = "PESEX_CODIGO", referencedColumnName = "PESEX_CODIGO")
    @JsonIgnoreProperties("empleados")
    private Sexo sexo;
}