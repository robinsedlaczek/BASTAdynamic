export class Address {
    street: string;
    zipCode: string;
    city: string;
}

export class User {
    id: number;
    firstName: string;
    lastName: string;
    company: string;
    address: Address;
}
