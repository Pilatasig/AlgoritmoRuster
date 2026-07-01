package ec.edu.monster.entidades.jpa;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.util.List;

@Entity
@Table(name="XESIS_SISTE")

public class Sistema {
    @Id
    @Column(name="XESIS_CODIGO", columnDefinition="CHAR(1)", length=1)
    private String codigo;
    
    @Column(name="XESIS_DESCRI", nullable=false, length=50)
    private String descripcion;
    
    @OneToMany(mappedBy = "sistema")
    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler", "padre", "hijas", "sistema", "opcionesPerfil"})
    private List<Opcion> opciones;

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

    public List<Opcion> getOpciones() {
        return opciones;
    }

    public void setOpciones(List<Opcion> opciones) {
        this.opciones = opciones;
    }
    
}
