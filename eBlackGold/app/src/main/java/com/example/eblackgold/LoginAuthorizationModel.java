package com.example.eblackgold;

public class LoginAuthorizationModel {
    public String login;
    public String password;
    public String role;

    public LoginAuthorizationModel(String login, String password, String role) {
        this.login = login;
        this.password = password;
        this.role = role;
    }
}
