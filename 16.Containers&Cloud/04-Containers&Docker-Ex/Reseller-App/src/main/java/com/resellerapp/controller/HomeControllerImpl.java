package com.resellerapp.controller;

import com.resellerapp.model.dto.UsersWithOffersDTO;
import com.resellerapp.model.entity.Offer;
import com.resellerapp.model.entity.User;
import com.resellerapp.service.OfferServiceImpl;
import com.resellerapp.service.UserServiceImpl;
import com.resellerapp.util.LoggedUser;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;

import java.util.Set;

@Controller
public class HomeControllerImpl implements HomeController {

    private final LoggedUser loggedUser;
    private final OfferServiceImpl offerService;
    private final UserServiceImpl userService;

    public HomeControllerImpl(LoggedUser loggedUser,
                              OfferServiceImpl offerService,
                              UserServiceImpl userService) {
        this.loggedUser = loggedUser;
        this.offerService = offerService;
        this.userService = userService;
    }

    @Override
    public String index() {
        if (loggedUser.isLogged()) {
            return "redirect:/home";
        }

        return "index";
    }

    @Override
    public String home(Model model) {
        if (!loggedUser.isLogged()) {
            return "redirect:/";
        }

        User user = userService.findUserById(loggedUser.getId()).orElse(null);
        model.addAttribute("currentUserInfo", user);
//        model.addAttribute("user", user);


//        Set<Offer> offersFromCurrentUser = this.offerService.getOffersFromCurrentUser(this.loggedUser.getId());
        Set<Offer> offersFromCurrentUser = this.userService.getOfferFromCurrentUser(this.loggedUser.getId());
        model.addAttribute("userOffers", offersFromCurrentUser);

//        Set<OffersWithUsernamesDTO> offersFromOtherUsers = this.offerService.getOffersFromOtherUsers(this.loggedUser.getId());
        Set<UsersWithOffersDTO> offersFromOtherUsers = this.userService.getOffersFromOtherUsers(this.loggedUser.getId());
        model.addAttribute("otherUserOffers", offersFromOtherUsers);

        int sum = 0;
        for (UsersWithOffersDTO e : offersFromOtherUsers) {
            int size = e.getOffers().size();
            sum += size;
        }
        model.addAttribute("totalOffers", sum);

        return "home";
    }


}
