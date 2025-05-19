import React from 'react';
import { ImageBackground, StyleSheet, View } from 'react-native';
import PageContainer from '../components/PageContainer.js';
import Button from '../components/Button.Js';
import { useNavigation } from '@react-navigation/native';

export default function ServiceCategories() {
  const navigation = useNavigation();

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
      resizeMode="cover"
    >
      <View style={styles.container}>
        <PageContainer>
          <Button title="SERVIÇOS POPULARES" onPress={() => navigation.navigate('ServicosPopulares')} />
          <Button title="OUTROS SERVIÇOS" onPress={() => navigation.navigate('OutrosServicos')} />
          <Button title="SERVIÇOS MILLENNIUM BARBEARIA" onPress={() => navigation.navigate('ServicosMillennium')} />
          <Button title="COMBOS ESPECIAIS MILLENNIUM" onPress={() => navigation.navigate('CombosMillennium')} />
        </PageContainer>
      </View>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  container: {
    flex: 1,
    justifyContent: 'flex-start',
    paddingHorizontal: 20,
    paddingTop: 300,
    backgroundColor: 'transparent',
  },
});
