(function () {
    angular.module("mbsite")
    .controller("weddingpartyController", ['$scope', function ($scope) {


        var Bridesmaids = new Array();
        Bridesmaids.push({ Name: "Katie Cunningham", Role: "Matron Of Honor", Desc: "Katie and Brittney have been close friends and cousins since birth.  Family events were never dull with their constant shenanigans.  Forever will these princesses reign over the \"kids  table\"." });
        Bridesmaids.push({ Name: "Janelle Markley", Role: "Bridesmaid", Desc: "Janelle and Brittney met while working in public accounting.  They became fast friends while working overtime in the trenches.  They currently work together at McKesson." });
        Bridesmaids.push({ Name: "Erin Medley", Role: "Bridesmaid", Desc: "Erin and Brittney met in college as sorority sisters in Alpha Omicron Pi.  In 2014 they became roommates for a year in Sandy Springs, and the memories are certainly entertaining!" });
        Bridesmaids.push({ Name: "Nikki Venturi", Role: "Bridesmaid", Desc: "Nikki and Brittney have been friends since birth.  They were next-door-neighbors until age 5 and kept in touch until reunited at Duluth High School where Nikki met her sweetheart, Bo.  Nikki and Brittney also had fun together in Statesboro, GA at Georgia Southern University." });
        Bridesmaids.push({ Name: "Rebecca Herad", Role: "Bridesmaid", Desc: "Rebecca and Brittney have been family now for over five years.  Rebecca married Brittney's brother, Brady, in 2010.  They live in Pensacola, FL." });
        $scope.bridesmaids = Bridesmaids;

        var Groomsmen = new Array();
        Groomsmen.push({ Name: "Justin LittLe", Role: "Best Man", Desc: "Justin is Matthew's <i>Little</i> brother. Matthew and Justin had their times competing against each other when they were younger, but they will always be brothers and love each other." });
        Groomsmen.push({ Name: "Nathan Stewart", Role: "Groomsman", Desc: "Nathan and Matthew met during their middle school years at First Presbyterian Church. They spent many Wednesday nights working together in the kitchen, and have been friends since!" });
        Groomsmen.push({ Name: "Jeff Turner", Role: "Groomsman", Desc: "Matthew and Jeff have known each other since before they were old enough to walk. Jeff and Matthew are friends for life, and along with Brian Griffin they make up the three musketeers of the culdesac." });
        Groomsmen.push({ Name: "Brian Griffin", Role: "Groomsman", Desc: "Brian and Matthew have been friends since Brian's family moved into the culdesac during their elementary school years. Brian, Matthew, and Jeff Turner have been on more adventures than they can count , and are friends for life." });
        Groomsmen.push({ Name: "Brady Pugh", Role: "Groomsman", Desc: "Brady is Brittney's brother, and met Matthew after he and Brittney had been dating for a few months. Brady and Matthew quickly became fast friends, and Matthew can't wait to have Brady as his Brother In Law." });
        $scope.groomsmen = Groomsmen;

    }]);
})();