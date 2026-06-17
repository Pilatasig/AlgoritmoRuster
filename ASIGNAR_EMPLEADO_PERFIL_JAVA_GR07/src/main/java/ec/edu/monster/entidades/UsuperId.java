package ec.edu.monster.entidades;

import java.io.Serializable;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 *
 * @author Usuario
 */
@Data
@NoArgsConstructor
@AllArgsConstructor
public class UsuperId implements Serializable {
    private static final long serialVersionUID = 1L;
    private String usuario;
    private String perfil;
}
