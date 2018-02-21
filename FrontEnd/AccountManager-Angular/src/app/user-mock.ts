import { User } from './user';

export const USERS: User[] = [
    {
        id: 2,
        firstName: 'Christian',
        lastName: 'Neubauer',
        company: '1&1 Internet SE',
        address: {
            street: 'Herrenäckerstraße 32',
            zipCode: '76530',
            city: 'Baden-Baden'
        }
    },
    {
        id: 1,
        firstName: 'Patrick',
        lastName: 'Tetz',
        company: '1&1 Internet SE',
        address: {
            street: '',
            zipCode: '',
            city: 'Grötzingen'
        }
    }
];
