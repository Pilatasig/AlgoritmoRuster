package ec.edu.monster.entidades.jpa;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.util.List;

@Entity
@Table(name = "XEOPC_OPCIO")
public class Opcion {

    @Id
    @Column(name = "XEOPC_CODIGO", columnDefinition = "CHAR(5)", length = 5)
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
    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler", "opciones"})
    private Sistema sistema;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "XEOPC_PADRE", referencedColumnName = "XEOPC_CODIGO")
    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler", "padre", "hijas", "sistema", "opcionesPerfil"})
    private Opcion padre;

    @OneToMany(mappedBy = "padre", fetch = FetchType.LAZY)
    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler", "padre", "hijas", "sistema", "opcionesPerfil"})
    private List<Opcion> hijas;

    @OneToMany(mappedBy = "opcion", fetch = FetchType.LAZY)
    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler", "opcion", "perfil"})
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

    public Opcion getPadre() {
        return padre;
    }

    public void setPadre(Opcion padre) {
        this.padre = padre;
    }

    public List<Opcion> getHijas() {
        return hijas;
    }

    public void setHijas(List<Opcion> hijas) {
        this.hijas = hijas;
    }

    public List<OpcPer> getOpcionesPerfil() {
        return opcionesPerfil;
    }

    public void setOpcionesPerfil(List<OpcPer> opcionesPerfil) {
        this.opcionesPerfil = opcionesPerfil;
    }
}