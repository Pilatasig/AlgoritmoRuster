package ec.edu.monster.entidades;

import jakarta.persistence.*;
import lombok.Data;
import java.util.List;

/**
 * @author Usuario
 */
@Data
@Entity
@Table(name = "XEPER_PERFI")
public class Perfil {

    @Id
    @Column(name = "XEPER_CODIGO", columnDefinition = "CHAR(8)", length = 8)
    private String codigo;

    @Column(name = "XEPER_DESCRI", nullable = false, length = 100)
    private String descripcion;

    @Lob
    @Column(name = "XEPER_OBSERV", columnDefinition = "TEXT")
    private String observaciones;

    // Relación bidireccional con la tabla intermedia OPCPER
    @OneToMany(mappedBy = "perfil", fetch = FetchType.LAZY)
    private List<OpcPer> opcionesPerfil;

    // Relación bidireccional hacia la tabla intermedia de usuario USUPE
    @OneToMany(mappedBy = "perfil", fetch = FetchType.LAZY)
    private List<Usuper> perfilesUsuario;
}