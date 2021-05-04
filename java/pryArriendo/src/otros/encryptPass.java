/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package otros;

/**
 *
 * @author Favio
 */
import org.apache.commons.codec.digest.DigestUtils;
public class encryptPass {
    public String encriptarPass(String pass) {
        return DigestUtils.sha256Hex(pass);
    }
}
