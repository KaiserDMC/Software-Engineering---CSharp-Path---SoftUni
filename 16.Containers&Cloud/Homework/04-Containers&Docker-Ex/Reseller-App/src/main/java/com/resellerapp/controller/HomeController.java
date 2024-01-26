package com.resellerapp.controller;

import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@RequestMapping(name = "/")
public interface HomeController {

    @GetMapping
    String index();

    @GetMapping("/home")
    String home(Model model);

}
