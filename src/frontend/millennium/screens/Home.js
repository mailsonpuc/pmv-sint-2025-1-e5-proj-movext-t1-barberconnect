import React from 'react';
import { ImageBackground, StyleSheet, View } from 'react-native';
import PageContainer from '../components/PageContainer.js';
import Button from '../components/Button.Js';
import { useNavigation } from '@react-navigation/native';

export default function Home() {
  const navigation = useNavigation();

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
    >
      <View style={styles.container}>
        <PageContainer>
          <Button title="AGENDAR HORÁRIO" onPress={() => navigation.navigate('ServiceCategories')} />
          <Button title="HISTÓRICO DE AGENDAMENTOS" onPress={() => navigation.navigate('Historico')} />
          <Button title="PRÓXIMOS AGENDAMENTOS" onPress={() => navigation.navigate('Proximos')} />
          <Button title="MINHA CONTA" onPress={() => navigation.navigate('MinhaConta')} />
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
    paddingTop: 280,
    backgroundColor: 'transparent',
  },
});
