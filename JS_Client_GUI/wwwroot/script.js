let brands = [];
let connection;
let idToUpdate = -1;
document.getElementById('update_container').style.display = "none";
getdata();
setupSignalR();
async function getdata() {
    await fetch('http://localhost:5000/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            console.log(brands);
            display();
        });
}
function display() {
    document.getElementById('brand_container').innerHTML = "";
    brands.forEach(x => {
        cars = "";
        x.cars.forEach(y => cars += '<div class="col">' + y.model + ' ' + y.production_year + '</div>');

        document.getElementById('brand_container').innerHTML +=
            '<div class="row border border-primary">' +
            '<div class="col p-2">' + x.id + '</div>' +
            '<div class="col p-2">' + x.name + '</div>' +
            '<div class="col p-2">' + cars + '</div>' +
            `<div class="col p-2"><button onclick="deletebrand(${x.id})" class="btn btn-danger">Delete</button></div>` +
            `<div class="col p-2"><button onclick="showupdate(${x.id})" class="btn btn-danger">Update</button></div>` +
            '</div>';
    });
}
function create() {
    let name = document.getElementById("brandname").value;
    if (name.length > 0)
        fetch('http://localhost:5000/brand', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(
                {
                    name: name
                }),
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getdata();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    document.getElementById("brandname").value = "";
    display();

}
function deletebrand(id) {
    fetch('http://localhost:5000/brand/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function update() {
    let name = document.getElementById('updatebrandname').value;
    document.getElementById('update_container').style.display = "none";
    fetch('http://localhost:5000/brand/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: name, id: idToUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showupdate(id) {
    document.getElementById('update_container').style.display = "block";
    document.getElementById('updatebrandname').value = brands.find(x => x['id'] == id)['name'];
    idToUpdate = id;
}
function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5000/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on
        ("BrandCreated", (user, message) => {
            console.log(user);
            console.log(message);
            getdata();
        });

    connection.on
        ("BrandUpdated", (user, message) => {
            console.log(user);
            console.log(message);
            getdata();
        });
    connection.on
        ("BrandDeleted", (user, message) => {
            console.log(user);
            console.log(message);
            getdata();
        });
    connection.on
        ("CarCreated", (user, message) => {
            console.log(user);
            console.log(message);
            getdata();
        });

    connection.on
        ("CarUpdated", (user, message) => {
            console.log(user);
            console.log(message);
            getdata();
        });
    connection.on
        ("CarDeleted", (user, message) => {
            console.log(user);
            console.log(message);
            getdata();
        });
    connection.onclose
        (async () => {
            await start();
        });
    start();

}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};