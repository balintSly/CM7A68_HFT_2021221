let brands=[];
fetch('http://localhost:5000/brand')
    .then(x => x.json())
    .then(y => {
        brands=y;
        console.log(brands);
        display();
    });
function display()
{
    brands.forEach(x=>{
document.getElementById("brand_rows").innerHTML+='<div class="col">Brand ID</div>';
    });
}