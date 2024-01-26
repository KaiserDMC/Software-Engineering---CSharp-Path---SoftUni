package com.resellerapp.model.dto;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class LoginDTO {

    private Long id;

    @Size(min = 3, max = 20, message = "Username length must be between 3 and 20 characters!")
    @NotNull
    private String username;

    @Size(min = 3, max = 20, message = "Password length must be between 3 and 20 characters!")
    @NotNull
    private String password;

    public LoginDTO() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
