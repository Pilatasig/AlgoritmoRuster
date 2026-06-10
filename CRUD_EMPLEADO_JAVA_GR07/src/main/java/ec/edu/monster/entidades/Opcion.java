package ec.edu.monster.entidades;

import jakarta.persistence.*;
import java.util.List;

/**
 * @author Usuario
 */
@Entity
@Table(name = "XEOPC_OPCIO")
public class Opcion {

    @Id
    @Column(name = "XEOPC_CODIGO", columnDefinition = "CHAR(3)", length = 3)
    private String codigo;

    @Column(name = "XEOPC_DESCRI", nullable = false, length = 100)
    private String descripcion;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(
        name = "XESIS_CODIGO", 
        referencedColumnName = "XESIS_CODIGO", 
        nullable = false,
        foreignKey = @ForeignKey(name = "FK_XEOPC_XESIS")
    )
    private Sistema sistema;

    // Relación hacia la tabla intermedia explícita
    @OneToMany(mappedBy = "opcion", fetch = FetchType.LAZY)
    private List<OpcPer> opcionesPerfil;

    public Opcion() {
    }

    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public Sistema getSistema() {
        return sistema;
    }

    public void setSistema(Sistema sistema) {
        this.sistema = sistema;
    }

    public List<OpcPer> getOpcionesPerfil() {
        return opcionesPerfil;
    }

    public void setOpcionesPerfil(List<OpcPer> opcionesPerfil) {
        this.opcionesPerfil = opcionesPerfil;
    }
    
    
}