package ec.edu.monster.entidades.jpa;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import java.io.Serializable;
import java.util.List;
import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.ToString;

/**
 * @author Usuario
 */
@Data
@Entity
@Table(name = "XEPER_PERFI")
public class Perfil implements Serializable {
    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "XEPER_CODIGO", columnDefinition = "CHAR(6)", length = 6)
    private String codigo;

    @Column(name = "XEPER_NOMBRE", nullable = false, length = 3)
    private String nombre;

    @Column(name = "XEPER_DESCRI", nullable = false, length = 100)
    private String descripcion;

    @Lob
    @Column(name = "XEPER_OBSERV", columnDefinition = "TEXT")
    private String observaciones;

    @JsonIgnore
    @OneToMany(mappedBy = "perfil", fetch = FetchType.LAZY)
    @ToString.Exclude
    @EqualsAndHashCode.Exclude
    private List<OpcPer> opcionesPerfil;

    @JsonIgnore
    @OneToMany(mappedBy = "perfil", fetch = FetchType.LAZY)
    @ToString.Exclude
    @EqualsAndHashCode.Exclude
    private List<Usuper> perfilesUsuario;
}