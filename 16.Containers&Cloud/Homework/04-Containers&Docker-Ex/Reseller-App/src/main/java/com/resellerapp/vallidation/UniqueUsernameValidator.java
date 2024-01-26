package com.resellerapp.vallidation;

import com.resellerapp.service.UserServiceImpl;
import com.resellerapp.vallidation.annotation.UniqueUsername;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

public class UniqueUsernameValidator implements ConstraintValidator<UniqueUsername, String> {

    private final UserServiceImpl userService;

    public UniqueUsernameValidator(UserServiceImpl userService) {
        this.userService = userService;
    }

    @Override
    public boolean isValid(String value, ConstraintValidatorContext context) {
        return this.userService.findUserByUsername(value) == null;
    }
}