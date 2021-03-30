db.createUser(
    {
        user: "pi",
        pwd: "hydro",
        roles: [
            {
                role: "readWrite",
                db: "hydropi"
            }
        ]
    }
)