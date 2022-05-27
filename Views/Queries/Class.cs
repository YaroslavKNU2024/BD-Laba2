//@model Query

//@{
//    ViewData["Title"] = "Запити";
//}

//< h1 > Запити </ h1 >
//< hr />

//< h3 > Прості </ h3 >
//< hr />

//< p style = "font-size:20px" >
 
//     < b > Запит 1 </ b >
//    </ p >
//    < p style = "font-size:17px" >
//         Обрати Штами, якими інфікована країна з індексом
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "SimpleQuery1" >
         
//                     < div class= "form-group" >
          
//                          < label class= "control-label" > Вірус: </ label >
              
//                              < input class= "form-control" id = "countryId" name = "countryId" type = "text" value = "" />
                      
//                                  </ div >
                      
//                                  < div class= "form-group" >
                       
//                                       < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                            
//                                        </ div >
                            
//                                    </ form >
                            
//                                </ div >
//                            </ div >
//                            < hr />
                            

//                            < p style = "font-size:20px" >
                             
//                                 < b > Запит 2 </ b >
//                                </ p >
//                                < p style = "font-size:17px" >
//                                     Обрати штами вірусу за назвою
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "SimpleQuery2" >
         
//                     < div class= "form-group" >
          
//                          < label class= "control-label" > Вірус: </ label >
              
//                              < input class= "form-control" id = "VirusName" name = "VirusName" type = "text" value = "" />
                      
//                                  </ div >
                      
//                                  < div class= "form-group" >
                       
//                                       < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                            
//                                        </ div >
                            
//                                    </ form >
                            
//                                </ div >
//                            </ div >
//                            < hr />
                            

//                            < p style = "font-size:20px" >
                             
//                                 < b > Запит 3 </ b >
//                                </ p >
//                                < p style = "font-size:17px" >
//                                     Знайти штами, для яких характерні симптоми за індексом
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "SimpleQuery3" >
         
//                     < div class= "form-group" >
          
//                          < label class= "control-label" > Симптом </ label >
           
//                           < input class= "form-control" id = "SymptomId" name = "SymptomId" type = "text" value = "" />
                   
//                               </ div >
                   
//                               < div class= "form-group" >
                    
//                                    < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                         

//                                     </ div >
                         
//                                 </ form >
                         
//                             </ div >
//                         </ div >
//                         < hr />
                         

//                         < p style = "font-size:20px" >
                          
//                              < b > Запит 4 </ b >
//                             </ p >
//                             < p style = "font-size:17px" >
//                                  Знайти к - ть інфікованих вірусомз ід
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "SimpleQuery4" >
         
//                     < div class= "form-group" >
          
//                          < label class= "control-label" > Симптом </ label >
           
//                           < input class= "form-control" id = "VirusId" name = "VirusId" type = "text" value = "" />
                   
//                               </ div >
                   
//                               < div class= "form-group" >
                    
//                                    < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                         

//                                     </ div >
                         
//                                 </ form >
                         
//                             </ div >
//                         </ div >
//                         < hr />
                         

//                         < p style = "font-size:20px" >
                          
//                              < b id = "q5" > Запит 5 </ b >
//                               </ p >
//                               < p style = "font-size:17px" >
//                                    Кількість заражених країн вірусом
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "SimpleQuery5" >
         
//                     < input type = "hidden" asp -for= "VirusName" value = "dummy" />
             
//                         < div class= "form-group" >
              
//                              < label asp -for= "Price" class= "control-label" ></ label >
                 
//                                 < input maxlength = "28" id = "price" asp -for= "Price" class= "form-control" />
                        
//                                        < span class= "text-danger" > @ViewBag.PriceError </ span >
                         
//                                     </ div >
                         
//                                     < div class= "form-group" >
                          
//                                          < input type = "submit" value = "Надіслати" class= "btn btn-success" onclick = "submit5()" />
                                
//                                            </ div >
                                
//                                        </ form >
                                
//                                    </ div >
//                                </ div >
//                                < hr />
                                

//                                < p style = "font-size:20px" >
                                 
//                                     < b > Запит 6 </ b >
//                                    </ p >
//                                    < p style = "font-size:17px" >
//                                         Знайти імена розробників, які не продають продукти з назвою Н.
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "SimpleQuery6" >
         
//                     < input type = "hidden" asp -for= "Price" value = "0" />
             
//                         < div class= "form-group" >
              
//                              < label class= "control-label" > Назва Н </ label >
                  
//                                  < input maxlength = "50" asp -for= "ProdName" class= "form-control" id = "prodName" />
                        
//                                        < span class= "text-danger" > @ViewBag.ProdNameError </ span >
                         
//                                     </ div >
                         
//                                     < div class= "form-group" >
                          
//                                          < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                               
//                                           </ div >
                               
//                                       </ form >
                               
//                                   </ div >
//                               </ div >
//                               < hr />
                               

//                               < h3 > Множинні </ h3 >
//                               < hr />
                               

//                               < p style = "font-size:20px" >
                                
//                                    < b > Запит 1 </ b >
//                                   </ p >
//                                   < p style = "font-size:17px" >
//                                        Знайти назви країн, розробники з яких продають програмні продукти принаймні за всіма тими цінами, що й розробник із кодом К.
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "AdvancedQuery1" >
         
//                     < input type = "hidden" asp -for= "ProdName" value = "dummy" />
             
//                         < input type = "hidden" asp -for= "Price" value = "0" />
                 
//                             < div class= "form-group" >
                  
//                                  < label class= "control-label" > Код розробника К</label>
//                                      <select asp-for="DevId" asp-items= "@ViewBag.DevIds" class= "form-control" ></ select >
                       
//                                   </ div >
                       
//                                   < div class= "form-group" >
                        
//                                        < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                             
//                                         </ div >
                             
//                                     </ form >
                             
//                                 </ div >
//                             </ div >
//                             < hr />
                             

//                             < p style = "font-size:20px" >
                              
//                                  < b > Запит 2 </ b >
//                                 </ p >
//                                 < p style = "font-size:17px" >
//                                      Знайти прізвища покупців, які придбали точно ті ж самі програмні продукти, що й покупець з email E.
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "AdvancedQuery2" >
         
//                     < input type = "hidden" asp -for= "ProdName" value = "dummy" />
             
//                         < input type = "hidden" asp -for= "Price" value = "0" />
                 
//                             < div class= "form-group" >
                  
//                                  < label class= "control-label" > Email E </ label >
                      
//                                      < select asp -for= "CustEmail" asp - items = "@ViewBag.CustEmails" class= "form-control" ></ select >
                             
//                                         </ div >
                             
//                                         < div class= "form-group" >
                              
//                                              < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                                   
//                                               </ div >
                                   
//                                           </ form >
                                   
//                                       </ div >
//                                   </ div >
//                                   < hr />

//@*< p style = "font-size:20px" >
 
//     < b > Запит 3 </ b >
//    </ p >
//    < p style = "font-size:17px" >
//         Знайти прізвища та email-и покупців з іменем І, які придбали всі наявні програмні продукти.
//</p>
//<div class= "row" >
//    < div class= "col-md-4" >
 
//         < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
        
//                < form asp - action = "AdvancedQuery3" >
         
//                     < input type = "hidden" asp -for= "ProdName" value = "dummy" />
             
//                         < input type = "hidden" asp -for= "Price" value = "0" />
                 
//                             < div class= "form-group" >
                  
//                                  < label class= "control-label" > Ім'я І</label>
//                                      < select asp -for= "CustName" asp - items = "@ViewBag.CustNames" class= "form-control" ></ select >
                             
//                                         </ div >
                             
//                                         < div class= "form-group" >
                              
//                                              < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                                   
//                                               </ div >
                                   
//                                           </ form >
                                   
//                                       </ div >
//                                   </ div >
//                                   < hr />
                                   

//                                   < div class= "container" style = "display:none" >
                                     
//                                         < h3 > Запити від викладача</h3>
//                                            <hr />

//    <p style = "font-size:20px;" >
                                        
//                                                < b > Запит 1</b>
//    </p>
//    <p style = "font-size:17px" >
//                                                Знайти..
//                                            </ p >
                                        
//                                            < div class= "row" >
                                         
//                                                 < div class= "col-md-4" >
                                          
//                                                      < form asp - action = "TeacherQuery1" >
                                           
//                                                           < input type = "hidden" asp -for= "ProdName" value = "dummy" />
                                               
//                                                               < input type = "hidden" asp -for= "Price" value = "0" />
                                                   
//                                                                   < div class= "form-group" >
                                                    

//                                                                    </ div >
                                                    
//                                                                    < div class= "form-group" >
                                                     
//                                                                         < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                                                          
//                                                                          </ div >
                                                          
//                                                                      </ form >
                                                          
//                                                                  </ div >
                                                          
//                                                              </ div >
                                                          
//                                                              < hr />
                                                          

//                                                              < p style = "font-size:20px;" >
                                                           
//                                                                   < b > Запит 2 </ b >
                                                              
//                                                                  </ p >
                                                              
//                                                                  < p style = "font-size:17px" >
//                                                                       Знайти..
//                                                                   </ p >
                                                               
//                                                                   < div class= "row" >
                                                                
//                                                                        < div class= "col-md-4" >
                                                                 
//                                                                             < form asp - action = "TeacherQuery2" >
                                                                  
//                                                                                  < input type = "hidden" asp -for= "ProdName" value = "dummy" />
                                                                      
//                                                                                      < input type = "hidden" asp -for= "Price" value = "0" />
                                                                          
//                                                                                          < div class= "form-group" >
                                                                           

//                                                                                           </ div >
                                                                           
//                                                                                           < div class= "form-group" >
                                                                            
//                                                                                                < input type = "submit" value = "Надіслати" class= "btn btn-success" />
                                                                                 
//                                                                                                 </ div >
                                                                                 
//                                                                                             </ form >
                                                                                 
//                                                                                         </ div >
                                                                                 
//                                                                                     </ div > *@
//    < hr />
//</ div >


//< form method = "get" asp - controller = "Home" asp - action = "Index" >
       
//           < input type = "submit" class= "btn btn-primary" value = "На головну" />
//           </ form >

//           @section scripts
//{
//    < script >
//        window.addEventListener("load", function() {
//        if ('@ViewBag.ErrorFlag' == 1)
//        {
//            document.getElementById("q4").scrollIntoView();
//        }
//        else if ('@ViewBag.ErrorFlag' == 2)
//        {
//            document.getElementById("q5").scrollIntoView();
//        }
//    });
//    </ script >
//}