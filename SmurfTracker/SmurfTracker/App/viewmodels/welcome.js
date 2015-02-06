﻿define(function() {
    var ctor = function () {
        this.displayName = 'LolSmurf Search';
        this.description = 'Durandal is a cross-device, cross-platform client framework written in JavaScript and designed to make Single Page Applications (SPAs) easy to create and maintain.';
        this.search = function() {
            var searchTerm = $('#searchBox').val();
            window.location.href += '#summoner?summonerName=' + searchTerm;
        }
    };

    //Note: This module exports a function. That means that you, the developer, can create multiple instances.
    //This pattern is also recognized by Durandal so that it can create instances on demand.
    //If you wish to create a singleton, you should export an object instead of a function.
    //See the "flickr" module for an example of object export.

    return ctor;
});