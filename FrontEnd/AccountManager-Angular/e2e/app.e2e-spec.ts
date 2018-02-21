import { BastaLabFrontendPage } from './app.po';

describe('basta-lab-frontend App', () => {
  let page: BastaLabFrontendPage;

  beforeEach(() => {
    page = new BastaLabFrontendPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
